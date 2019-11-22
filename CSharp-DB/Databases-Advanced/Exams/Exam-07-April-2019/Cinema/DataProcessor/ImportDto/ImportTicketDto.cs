namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        public int ProjectionId { get; set; }

        public decimal Price { get; set; }
    }
}
