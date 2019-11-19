using AutoMapper;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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
                Employee employee = Mapper.Map<Employee>(employeeDto);
                bool isValidEmployee = IsValid(employee);
                bool isValidPosition = IsValid(employeeDto);

                if (isValidEmployee == false || isValidPosition == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Position position = positions.FirstOrDefault(p => p.Name == employeeDto.PositionName);

                if (position == null)
                {
                    position = new Position
                    {
                        Name = employeeDto.PositionName
                    };

                    positions.Add(position);
                }

                employee.Position = position;

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
                var item = Mapper.Map<Item>(itemDto);
                bool isValidItem = IsValid(item);
                bool isValidCategoryName = IsValid(itemDto);
                bool isItemExist = items.Any(i => i.Name == item.Name);

                if (isValidItem == false || isValidCategoryName == false || isItemExist == true)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                Category category = categories.FirstOrDefault(c => c.Name == itemDto.CategoryName);

                if (category == null)
                {
                    category = new Category
                    {
                        Name = itemDto.CategoryName
                    };

                    categories.Add(category);
                }

                item.Category = category;

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
                bool isValidOrderType = Enum.IsDefined(typeof(OrderType), orderDto.Type);

                if (isValidOrderType == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var order = Mapper.Map<Order>(orderDto);

                bool isValidOrder = IsValid(order);
                Employee targetEmployee = context.Employees
                    .FirstOrDefault(e => e.Name == orderDto.EmployeeName);

                var itemsNames = context.Items.Select(i => i.Name).ToList();
                var itemsExists = orderDto.Items.Select(i => i.ItemName)
                    .All(value => itemsNames.Contains(value));

                if (isValidOrder == false || targetEmployee == null || itemsExists == false)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                foreach (var itemDto in orderDto.Items)
                {
                    var targetItem = context.Items.FirstOrDefault(i => i.Name == itemDto.ItemName);

                    OrderItem orderItem = new OrderItem
                    {
                        Item = targetItem,
                        ItemId = targetItem.Id,
                        Order = order,
                        OrderId = order.Id,
                        Quantity = itemDto.Quantity
                    };

                    order.OrderItems.Add(orderItem);
                }

                order.Employee = targetEmployee;

                orders.Add(order);
                sb.AppendLine(string.Format(OrderMessage,
                    order.Customer,
                    order.DateTime.ToString("dd/MM/yyyy HH:mm")));
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