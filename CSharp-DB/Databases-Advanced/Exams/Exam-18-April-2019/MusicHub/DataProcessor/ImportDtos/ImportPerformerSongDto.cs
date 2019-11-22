namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportPerformerSongDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
