namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;

    using Data;

    using Footballers.Data.Models;
    using Footballers.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(CoachImportDto[]), new XmlRootAttribute("Coaches"));
            using (StringReader reader = new StringReader(xmlString))
            {
                var coaches = (CoachImportDto[])serializer.Deserialize(reader);

                foreach (var coach in coaches)
                {
                    if (IsValid(coach))
                    {
                        foreach (var footballer in coach.Footballers)
                        {
                            if (IsValid(footballer))
                            {
                                var startDate = DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                var endDate = DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                                if (DateTime.Compare(startDate, endDate) < 0)
                                {
                                    var footballerData = Mapper.Map<Footballer>(footballer);
                                }
                                else
                                {
                                    sb.AppendLine("Invalid data!");
                                }
                            }
                            else
                            {
                                sb.AppendLine("Invalid data!");
                            }
                        }
                    }
                    else
                    {
                        sb.AppendLine("Invalid data!");
                    }
                }
            }

            throw new NotImplementedException();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}