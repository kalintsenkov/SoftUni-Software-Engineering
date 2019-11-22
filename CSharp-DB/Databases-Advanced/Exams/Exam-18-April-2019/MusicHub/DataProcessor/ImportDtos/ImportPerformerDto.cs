namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public ImportPerformerSongDto[] PerformersSongs { get; set; }
    }
}
