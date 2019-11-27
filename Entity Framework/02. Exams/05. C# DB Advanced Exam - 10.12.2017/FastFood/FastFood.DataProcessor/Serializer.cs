using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var result = context.Employees
                .Where(e => e.Name == employeeName)
                .Select(e => new ExportEmployeeWithOrdersDto
                {
                    Name = e.Name,
                    Orders = e.Orders
                    .Where(o => o.Type.ToString() == orderType)
                    .Select(o => new ExportOrdersByEmployeeDto
                    {
                        Customer = o.Customer,
                        Items = o.OrderItems.Select(oi => new ExportItemsForOrderDto
                        {
                            Name = oi.Item.Name,
                            Price = oi.Item.Price,
                            Quantity = oi.Quantity
                        })
                        .ToList(),
                        TotalPrice = o.TotalPrice
                    })
                    .OrderByDescending(o => o.TotalPrice)
                    .ThenByDescending(o => o.Items.Count)
                    .ToList(),
                    TotalMade = e.Orders.Sum(p => p.TotalPrice)
                })
                .ToList();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            string[] categories = categoriesString
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var result = context.Categories
                .Where(c => categories.Contains(c.Name))
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = c.Items.Select(i => new ExportMostPopularItemDto
                    {
                        Name = i.Name,
                        TotalMade = i.Price * i.OrderItems.Sum(oi => oi.Quantity),
                        TimesSold = i.OrderItems.Sum(oi => oi.Quantity)
                    })
                    .OrderByDescending(i => i.TotalMade)
                    .FirstOrDefault()
                })
                .OrderByDescending(i => i.MostPopularItem.TotalMade)
                .ThenByDescending(i => i.MostPopularItem.TimesSold)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), result, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}