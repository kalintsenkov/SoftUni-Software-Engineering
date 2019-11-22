namespace MusicHub
{
    using System.IO;

    using Microsoft.EntityFrameworkCore;
   
    using Data;
    using DataProcessor;

    public class StartUp
    {
        public static void Main(string[] args)
        {
        }

        private static void ResetDatabase(MusicHubDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var inputWritersJson = File.ReadAllText(@".\..\..\..\Datasets\ImportWriters.json");
            var writersResult = Deserializer.ImportWriters(context, inputWritersJson);

            var inputProducersJson = File.ReadAllText(@".\..\..\..\Datasets\ImportProducersAlbums.json");
            var producersAlbumsResult = Deserializer.ImportProducersAlbums(context, inputProducersJson);

            var inputSongsXml = File.ReadAllText(@".\..\..\..\Datasets\ImportSongs.xml");
            var songsResult = Deserializer.ImportSongs(context, inputSongsXml);

            var inputSongPerformersXml = File.ReadAllText(@".\..\..\..\Datasets\ImportSongPerformers.xml");
            var songPerformersResult = Deserializer.ImportSongPerformers(context, inputSongPerformersXml);
        }
    }
}
