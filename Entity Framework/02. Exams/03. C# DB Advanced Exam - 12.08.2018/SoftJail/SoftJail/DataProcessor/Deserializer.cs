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
        private const string SuccessfullyAddedDepartmentWithCells = "Imported {0} with {1} cells";
        private const string SuccessfullyAddedPrisonerWithMails = "Imported {0} {1} years old";
        private const string SuccessfullyAddedOfficeWithPrisoners = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
            List<Department> departmets = new List<Department>();

            StringBuilder sb = new StringBuilder();

            foreach (var departmentDto in departmentsDto)
            {
                var department = Mapper.Map<Department>(departmentDto);
                bool isValidDepartment = IsValid(department);

                var cells = departmentDto.Cells
                    .Select(c => Mapper.Map<Cell>(c))
                    .ToList();
                var isValidCells = cells.Any(c => IsValid(c) != true);

                if (isValidDepartment == false || isValidCells == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cell in cells)
                {
                    if (department.Cells.FirstOrDefault(c => c.CellNumber == cell.CellNumber) == null)
                    {
                        department.Cells.Add(cell);
                    }
                }

                departmets.Add(department);

                sb.AppendLine(string.Format(SuccessfullyAddedDepartmentWithCells,
                    department.Name,
                    department.Cells.Count));
            }

            context.Departments.AddRange(departmets);
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

                var mails = prisonerDto.Mails
                    .Select(m => Mapper.Map<Mail>(m))
                    .ToList();
                var isValidMails = mails.Any(m => IsValid(m) != true);

                var isValidCell = context.Cells.Find(prisonerDto.CellId);

                if (isValidPrisoner == false || isValidMails == true || isValidCell == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var mail in mails)
                {
                    prisoner.Mails.Add(mail);
                }

                prisoners.Add(prisoner);

                sb.AppendLine(string.Format(SuccessfullyAddedPrisonerWithMails,
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
                if (Enum.IsDefined(typeof(Position), officerDto.Position) == false ||
                    Enum.IsDefined(typeof(Weapon), officerDto.Weapon) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = Mapper.Map<Officer>(officerDto);
                bool isValidOfficer = IsValid(officer);

                var prisoners = context.Prisoners.Select(x => x.Id).ToList();
                var isValidPrisoners = prisoners.Any(p => officerDto.PrisonerIds.Any(c => c.Id != p));

                if (isValidOfficer == false || isValidPrisoners == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var prisonerIds in officerDto.PrisonerIds)
                {
                    OfficerPrisoner officerPrisoner = new OfficerPrisoner
                    {
                        Officer = officer,
                        OfficerId = officer.Id,
                        Prisoner = context.Prisoners.Find(prisonerIds.Id),
                        PrisonerId = prisonerIds.Id
                    };

                    officer.OfficerPrisoner.Add(officerPrisoner);
                }

                officers.Add(officer);

                sb.AppendLine(string.Format(SuccessfullyAddedOfficeWithPrisoners, officer.FullName, officer.OfficerPrisoner.Count()));
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