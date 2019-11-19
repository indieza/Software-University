using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var type = Enum.Parse<OrderType>(orderType);

            var employee = context
                .Employees.Where(e => e.Name == employeeName)
                .Select(e => new ExportOrderDto
                {
                    EmployeeName = e.Name,
                    Orders = e.Orders.Where(o => o.Type == type).Select(o => new ExportOrderItemsDto
                    {
                        CustomerName = o.Customer,
                        Items = o.OrderItems.Select(oi => new ExportItemDto
                        {
                            Name = oi.Item.Name,
                            Price = oi.Item.Price,
                            Quantity = oi.Quantity
                        })
                        .ToArray(),
                        TotalPrice = o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity)
                    })
                    .OrderByDescending(o => o.TotalPrice)
                    .ThenByDescending(o => o.Items.Count())
                    .ToArray(),
                    TotalMade = e.Orders
                    .Where(o => o.Type == type)
                    .Sum(o => o.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);

            return json;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            throw new NotImplementedException();
        }
    }
}