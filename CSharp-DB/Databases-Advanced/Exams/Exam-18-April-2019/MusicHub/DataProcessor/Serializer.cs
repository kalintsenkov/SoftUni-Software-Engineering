namespace MusicHub.DataProcessor
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using ExportDtos;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.Producer.Id == producerId)
                .OrderByDescending(a => a.Songs.Sum(s => s.Price))
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = $"{s.Price:F2}",
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToList(),
                    AlbumPrice = $"{a.Songs.Sum(s => s.Price):F2}"
                })
                .ToList();

            var albumsJson = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return albumsJson;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            using var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            var serializer = new XmlSerializer(typeof(ExportSongDto[]), new XmlRootAttribute("Songs"));
            serializer.Serialize(writer, songs, ns);

            var songsXml = writer.GetStringBuilder();

            return songsXml.ToString().TrimEnd();
        }
    }
}