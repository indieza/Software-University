﻿namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .Select(p => new ExportPrisonerWithOfficersDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new ExportOfficerDto
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary).ToString("F2")
                })
                .OrderBy(p => p.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new ExportMailDto
                    {
                        Description = ReverseDescription(m.Description)
                    })
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }

        private static string ReverseDescription(string description)
        {
            char[] charArray = description.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}