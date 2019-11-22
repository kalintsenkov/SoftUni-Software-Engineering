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

            var validWriters = new List<Writer>();
            var result = new StringBuilder();

            foreach (var dto in writerDtos)
            {
                var writer = new Writer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym
                };

                if (!IsValid(writer))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validWriters.Add(writer);

                result.AppendLine(string.Format(
                    SuccessfullyImportedWriter,
                    writer.Name));
            }

            context.Writers.AddRange(validWriters);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producerDtos = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);

            var validProducers = new List<Producer>();
            var result = new StringBuilder();

            foreach (var dto in producerDtos)
            {
                var producer = new Producer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym,
                    PhoneNumber = dto.PhoneNumber
                };

                if (!IsValid(producer) || dto.Albums.Any(a => !IsValid(a)))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var albumDto in dto.Albums)
                {
                    var album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime
                            .ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                validProducers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    result.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count));
                }
                else
                {
                    result.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count));
                }
            }

            context.Producers.AddRange(validProducers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songDtos = (ImportSongDto[])serializer.Deserialize(reader);

            var validSongs = new List<Song>();
            var result = new StringBuilder();

            foreach (var dto in songDtos)
            {
                var name = dto.Name;
                var duration = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);
                var createdOn = DateTime.ParseExact(dto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var genre = Enum.TryParse(dto.Genre, out Genre genreResult);
                var albumId = dto.AlbumId;
                var writerId = dto.WriterId;
                var price = dto.Price;

                var song = new Song
                {
                    Name = name,
                    Duration = duration,
                    CreatedOn = createdOn,
                    Genre = genreResult,
                    AlbumId = albumId,
                    WriterId = writerId,
                    Price = price
                };

                var isWriterIdValid = context.Writers.Any(w => w.Id == writerId);
                var isAlbumIdValid = context.Albums.Any(a => a.Id == albumId);

                if (!IsValid(song) || !genre || !isWriterIdValid || !isAlbumIdValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validSongs.Add(song);

                result.AppendLine(string.Format(
                    SuccessfullyImportedSong,
                    song.Name,
                    song.Genre.ToString(),
                    song.Duration.ToString("c")));
            }

            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            var performerDtos = (ImportPerformerDto[])serializer.Deserialize(reader);

            var validPerformers = new List<Performer>();
            var result = new StringBuilder();

            foreach (var dto in performerDtos)
            {
                var performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth
                };

                if (!IsValid(performer))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var songIds = dto.PerformersSongs
                    .Select(ps => ps.Id)
                    .ToArray();

                var isSongIdInvalid = false;

                foreach (var songId in songIds)
                {
                    if (!context.Songs.Any(s => s.Id == songId))
                    {
                        isSongIdInvalid = true;
                        break;
                    }

                    var songPerformer = new SongPerformer
                    {
                        SongId = songId
                    };

                    performer.PerformerSongs.Add(songPerformer);
                }

                if (isSongIdInvalid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validPerformers.Add(performer);

                result.AppendLine(string.Format(
                    SuccessfullyImportedPerformer,
                    performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
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