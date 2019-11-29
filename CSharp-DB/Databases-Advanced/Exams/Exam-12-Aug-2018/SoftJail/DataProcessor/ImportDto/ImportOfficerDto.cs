namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        public string Position { get; set; }

        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerIdDto[] Prisoners { get; set; }
    }
}
