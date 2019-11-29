namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Message")]
    public class EncryptedMessageDto
    {
        public string Description { get; set; }
    }
}
