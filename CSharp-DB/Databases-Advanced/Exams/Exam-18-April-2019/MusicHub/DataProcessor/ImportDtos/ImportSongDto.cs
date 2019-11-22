namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDto
    {
        public string Name { get; set; }

        public string Duration { get; set; }

        public string CreatedOn { get; set; }

        public string Genre { get; set; }

        public int AlbumId { get; set; }

        public int WriterId { get; set; }

        public decimal Price { get; set; }
    }
}
