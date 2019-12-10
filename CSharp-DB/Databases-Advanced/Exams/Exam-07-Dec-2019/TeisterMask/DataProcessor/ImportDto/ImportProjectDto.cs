namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ImportProjectDto
    {
        [Required]
        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportTaskDto[] Tasks { get; set; }
    }
}
