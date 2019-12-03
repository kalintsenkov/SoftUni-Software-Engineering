namespace MusicHub
{
    using System;
    using System.IO;

    using Microsoft.EntityFrameworkCore;
   
    using Data;
    using DataProcessor;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var context = new MusicHubDbContext();

            //ResetDatabase(context);

            var result = Serializer.ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        private static void ResetDatabase(MusicHubDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var writersJson = File.ReadAllText(@".\..\..\..\Datasets\ImportWriters.json");
            var writersResult = Deserializer.ImportWriters(context, writersJson);

            var producersJson = File.ReadAllText(@".\..\..\..\Datasets\ImportProducersAlbums.json");
            var producersResult = Deserializer.ImportProducersAlbums(context, producersJson);

            var songsXml = File.ReadAllText(@".\..\..\..\Datasets\ImportSongs.xml");
            var songsResult = Deserializer.ImportSongs(context, songsXml);

            var performersXml = File.ReadAllText(@".\..\..\..\Datasets\ImportSongPerformers.xml");
            var performersResult = Deserializer.ImportSongPerformers(context, performersXml);
        }
    }
}
