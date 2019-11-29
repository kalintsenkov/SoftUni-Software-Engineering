namespace SoftJail.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    
    using Data;
    using ExportDto;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(o => new
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var prisonersJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prisonersJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersNamesParts = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .Where(p => prisonersNamesParts.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate
                        .ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new EncryptedMessageDto
                        {
                            Description = ReverseText(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            serializer.Serialize(writer, prisoners, ns);

            var prisonersXml = writer.GetStringBuilder();

            return prisonersXml.ToString().TrimEnd();
        }

        private static string ReverseText(string text)
        {
            var reversedText = string.Empty;

            for (int i = text.Length - 1; i >= 0; i--)
            {
                reversedText += text[i];
            }

            return reversedText;
        }
    }
}