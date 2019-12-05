namespace VaporStore.DataProcessor
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
    using Dto.Import;

    public static class Deserializer
	{
        private const string ErrorMessage
            = "Invalid Data";
        private const string SuccessfullyImportedGameMessage
            = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullyImportedUserMessage
            = "Imported {0} with {1} cards";
        private const string SuccessfullyImportedPurchaseMessage
            = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            var sb = new StringBuilder();

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto) || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }

                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(
                        gameDto.ReleaseDate,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre
                };
                
                ImportGameTags(tags, gameDto, game);

                games.Add(game);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedGameMessage,
                    game.Name,
                    genre.Name,
                    game.GameTags.Count));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();
            var sb = new StringBuilder();

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) || userDto.Cards.Any(c => !IsValid(c)) || !userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userDto.Cards
                        .Select(c => new Card
                        {
                            Number = c.Number,
                            Cvc = c.Cvc,
                            Type = (CardType)Enum.Parse(typeof(CardType), c.Type)
                        })
                        .ToArray()
                };

                users.Add(user);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedUserMessage,
                    user.Username,
                    user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(
                typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));
            var purchasesDtos = (ImportPurchaseDto[])xmlSerializer.Deserialize(reader);

            var purchases = new List<Purchase>();
            var sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDtos)
            {
                var isPurchaseValid = IsValid(purchaseDto);
                var isPurchaseTypeValid = Enum.TryParse(purchaseDto.Type, out PurchaseType type);
                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (!isPurchaseValid || !isPurchaseTypeValid || game == null || card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = type,
                    ProductKey = purchaseDto.Key,
                    Date = DateTime.ParseExact(
                        purchaseDto.Date,
                        @"dd/MM/yyyy HH:mm",
                        CultureInfo.InvariantCulture),
                    Card = card,
                    Game = game
                };

                purchases.Add(purchase);

                var username = context.Cards
                    .Where(c => c.Number == purchaseDto.Card)
                    .Select(c => c.User.Username)
                    .FirstOrDefault();

                sb.AppendLine(string.Format(
                    SuccessfullyImportedPurchaseMessage,
                    game.Name,
                    username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        private static void ImportGameTags(ICollection<Tag> tags, ImportGameDto gameDto, Game game)
        {
            foreach (var tagName in gameDto.Tags)
            {
                var tag = tags.FirstOrDefault(t => t.Name == tagName);

                if (tag == null)
                {
                    tag = new Tag
                    {
                        Name = tagName
                    };

                    tags.Add(tag);
                }

                game.GameTags.Add(new GameTag
                {
                    Tag = tag
                });
            }
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