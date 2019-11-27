using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string OrderMessage = "Order for {0} on {1} added";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();
            List<Position> positions = new List<Position>();

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeesDto)
            {
                bool isValidDto = IsValid(employeeDto);

                if (isValidDto == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = positions.FirstOrDefault(p => p.Name == employeeDto.Position);

                if (position == null)
                {
                    position = new Position
                    {
                        Name = employeeDto.Position
                    };

                    positions.Add(position);
                }

                Employee employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position,
                    PositionId = position.Id
                };

                employees.Add(employee);

                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemsDto = JsonConvert.DeserializeObject<ImportItemDto[]>(jsonString);

            List<Item> items = new List<Item>();
            List<Category> categories = new List<Category>();

            StringBuilder sb = new StringBuilder();

            foreach (var itemDto in itemsDto)
            {
                bool isValidDto = IsValid(itemDto);

                if (isValidDto == false || items.Any(i => i.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = categories.FirstOrDefault(p => p.Name == itemDto.Category);

                if (category == null)
                {
                    category = new Category
                    {
                        Name = itemDto.Category
                    };

                    categories.Add(category);
                }

                Item item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category,
                    CategoryId = category.Id
                };

                items.Add(item);

                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(items);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOrderDto[]), new XmlRootAttribute("Orders"));
            var ordersDto = (ImportOrderDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Order> orders = new List<Order>();

            StringBuilder sb = new StringBuilder();

            foreach (var orderDto in ordersDto)
            {
                bool isValidDto = IsValid(orderDto);
                var employee = context.Employees.FirstOrDefault(e => e.Name == orderDto.Employee);
                var itemsNames = context.Items.Select(i => i.Name).ToList();
                var isValidItems = orderDto.Items.Select(i => i.Name).All(v => itemsNames.Contains(v));
                var isValidOrderType = Enum.IsDefined(typeof(OrderType), orderDto.Type);

                if (isValidDto == false ||
                    employee == null ||
                    isValidItems == false ||
                    isValidOrderType == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Order order = new Order
                {
                    Customer = orderDto.Customer,
                    DateTime = DateTime.ParseExact(
                        orderDto.DateTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Employee = employee,
                    EmployeeId = employee.Id,
                    Type = (OrderType)Enum.Parse(typeof(OrderType), orderDto.Type),
                    OrderItems = orderDto.Items.Select(i => new OrderItem
                    {
                        Item = context.Items
                        .FirstOrDefault(t => t.Name == i.Name),
                        Quantity = i.Quantity
                    })
                    .ToList()
                };

                orders.Add(order);

                sb.AppendLine(string.Format(OrderMessage,
                    order.Customer,
                    order.DateTime.ToString(@"dd/MM/yyyy HH:mm")));
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}