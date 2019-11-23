namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportedDepartment = "Imported {0} with {1} cells";
        private const string ImportedPrisoner = "Imported {0} {1} years old";
        private const string ImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            StringBuilder sb = new StringBuilder();

            foreach (var departmentDto in departmentsDto)
            {
                var department = Mapper.Map<Department>(departmentDto);

                bool isValidDepartment = IsValid(department);
                bool isValidCells = department.Cells.Any(c => IsValid(c) == false);

                if (isValidDepartment == false || isValidCells == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(department);

                sb.AppendLine(string.Format(ImportedDepartment,
                    department.Name,
                    department.Cells.Count()));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            StringBuilder sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                var prisoner = Mapper.Map<Prisoner>(prisonerDto);

                bool isValidPrisoner = IsValid(prisoner);
                bool isValidMails = prisoner.Mails.Any(m => IsValid(m) == false);

                if (isValidPrisoner == false || isValidMails == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(prisoner);

                sb.AppendLine(string.Format(ImportedPrisoner,
                    prisoner.FullName,
                    prisoner.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            var officersDto = (ImportOfficerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Officer> officers = new List<Officer>();

            StringBuilder sb = new StringBuilder();

            foreach (var officerDto in officersDto)
            {
                bool isValidPosition = Enum.IsDefined(typeof(Position), officerDto.Position);
                bool isValidWeapon = Enum.IsDefined(typeof(Weapon), officerDto.Weapon);

                if (isValidPosition == false || isValidWeapon == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = Mapper.Map<Officer>(officerDto);
                bool isValidOfficer = IsValid(officer);

                if (isValidOfficer == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                officer.OfficerPrisoners = officerDto.Prisoners
                    .Select(p => new OfficerPrisoner { PrisonerId = p.Id })
                    .ToList();

                officers.Add(officer);

                sb.AppendLine(string.Format(ImportedOfficer,
                    officer.FullName,
                    officer.OfficerPrisoners.Count()));
            }

            context.Officers.AddRange(officers);
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