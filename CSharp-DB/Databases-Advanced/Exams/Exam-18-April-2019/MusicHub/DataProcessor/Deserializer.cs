namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDtos;

    public class Deserializer
    {
        private const string ErrorMessage
            = "Invalid data";
        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writerDtos = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var writers = new List<Writer>();
            var sb = new StringBuilder();

            foreach (var writerDto in writerDtos)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedWriter,
                    writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producerDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var producers = new List<Producer>();
            var sb = new StringBuilder();

            foreach (var producerDto in producerDtos)
            {
                if (!IsValid(producerDto) || producerDto.Albums.Any(a => !IsValid(a)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber,
                    Albums = producerDto.Albums
                        .Select(a => new Album
                        {
                            Name = a.Name,
                            ReleaseDate = DateTime
                                .ParseExact(a.ReleaseDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                };

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songDtos = (ImportSongDto[])xmlSerializer.Deserialize(reader);

            var songs = new List<Song>();
            var sb = new StringBuilder();

            foreach (var songDto in songDtos)
            {
                var isGenreValid = Enum.TryParse(songDto.Genre, out Genre genre);
                var isAlbumIdValid = context.Albums.Any(a => a.Id == songDto.AlbumId);
                var isWriterIdValid = context.Writers.Any(w => w.Id == songDto.WriterId);

                if (!IsValid(songDto) || !isGenreValid || !isAlbumIdValid || !isWriterIdValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genre,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                songs.Add(song);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedSong,
                    song.Name,
                    song.Genre.ToString(),
                    song.Duration.ToString()));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            var performerDtos = (ImportPerformerDto[])xmlSerializer.Deserialize(reader);

            var performers = new List<Performer>();
            var sb = new StringBuilder();

            foreach (var performerDto in performerDtos)
            {
                var isSongIdsValid = true;

                foreach (var song in performerDto.PerformersSongs)
                {
                    if (!context.Songs.Any(s => s.Id == song.Id))
                    {
                        isSongIdsValid = false;
                        break;
                    }
                }

                if (!IsValid(performerDto) || !isSongIdsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth,
                    PerformerSongs = performerDto.PerformersSongs
                        .Select(ps => new SongPerformer
                        {
                            SongId = ps.Id
                        })
                        .ToArray()
                };

                performers.Add(performer);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedPerformer,
                    performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object instance)
        {
            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(instance, validationContext, validationResults, true);

            return isValid;
        }
    }
}