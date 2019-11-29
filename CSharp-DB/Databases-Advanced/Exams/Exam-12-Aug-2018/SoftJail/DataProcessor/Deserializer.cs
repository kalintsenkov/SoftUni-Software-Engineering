namespace SoftJail.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage
            = "Invalid Data";
        private const string SuccessfullyImportedDepartment
            = "Imported {0} with {1} cells";
        private const string SuccessfullyImportedPrisoner
            = "Imported {0} {1} years old";
        private const string SuccessfullyImportedOfficer
            = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var validDepartments = new List<Department>();
            var sb = new StringBuilder();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto) || departmentDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                    Cells = departmentDto.Cells
                        .Select(c => new Cell
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToList()
                };

                validDepartments.Add(department);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedDepartment,
                    department.Name,
                    department.Cells.Count));
            }

            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var validPrisoners = new List<Prisoner>();
            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto) || prisonerDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var releaseDate = GetReleaseDate(prisonerDto);

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = prisonerDto.Mails
                        .Select(m => new Mail
                        {
                            Description = m.Description,
                            Sender = m.Sender,
                            Address = m.Address
                        })
                        .ToList()
                };

                validPrisoners.Add(prisoner);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedPrisoner,
                    prisoner.FullName,
                    prisoner.Age));
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            var officerDtos = (ImportOfficerDto[])serializer.Deserialize(reader);

            var validOfficers = new List<Officer>();
            var sb = new StringBuilder();

            foreach (var officerDto in officerDtos)
            {
                var isPositionValid = Enum.TryParse(officerDto.Position, out Position position);
                var isWeaponValid = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if (!IsValid(officerDto) || !isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = officerDto.DepartmentId
                };

                foreach (var prisoner in officerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisoner.Id
                    });
                }

                validOfficers.Add(officer);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedOfficer,
                    officer.FullName,
                    officer.OfficerPrisoners.Count));
            }

            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static DateTime? GetReleaseDate(ImportPrisonerDto prisonerDto)
        {
            DateTime? releaseDate = null;

            if (prisonerDto.ReleaseDate != null)
            {
                releaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            return releaseDate;
        }

        private static bool IsValid(object instance)
        {
            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(instance, validationContext, validationResults, true);

            return isValid;
        }
    }
}