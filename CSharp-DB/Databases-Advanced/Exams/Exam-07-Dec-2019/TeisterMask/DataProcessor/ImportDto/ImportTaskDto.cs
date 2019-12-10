namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class ImportTaskDto
    {
        [Required]
        [MinLength(2), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        public int ExecutionType { get; set; }

        public int LabelType { get; set; }
    }
}
