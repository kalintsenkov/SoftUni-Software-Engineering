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
        private const string SuccessfullyImportedGame
            = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullyImportedUser
            = "Imported {0} with {1} cards";
        private const string SuccessfullyImportedPurchase
            = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var validGames = new List<Game>();
            var validDevelopers = new List<Developer>();
            var validGenres = new List<Genre>();
            var validTags = new List<Tag>();

            var result = new StringBuilder();

            foreach (var gameDto in gameDtos)
            {
                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime
                        .ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                var developer = validDevelopers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    validDevelopers.Add(developer);
                }

                var genre = validGenres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    validGenres.Add(genre);
                }

                var isDeveloperValid = IsValid(developer);
                var isGenreValid = IsValid(genre);
                var isGameValid = IsValid(game);
                var isTagValid = true;

                var tags = new List<Tag>();

                foreach (var tagName in gameDto.Tags)
                {
                    var tag = validTags.FirstOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        validTags.Add(tag);
                    }

                    if (!IsValid(tag))
                    {
                        isTagValid = false;
                        break;
                    }

                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
                }

                game.Developer = developer;
                game.Genre = genre;

                if (!isDeveloperValid || !isGenreValid || !isGameValid || !isTagValid || game.GameTags.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validGames.Add(game);

                result.AppendLine(string.Format(
                    SuccessfullyImportedGame,
                    game.Name,
                    game.Genre.Name,
                    game.GameTags.Count));
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var validUsers = new List<User>();
            var validCards = new List<Card>();

            var result = new StringBuilder();

            foreach (var userDto in userDtos)
            {
                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                var isCardValid = true;

                foreach (var cardDto in userDto.Cards)
                {
                    var card = validCards.FirstOrDefault(c => c.Number == cardDto.Number);
                    var isCardTypeValid = true;

                    if (card == null)
                    {
                        isCardTypeValid = Enum.TryParse(cardDto.Type, out CardType type);

                        card = new Card
                        {
                            Number = cardDto.Number,
                            Cvc = cardDto.Cvc,
                            Type = type
                        };

                        validCards.Add(card);
                    }

                    if (!IsValid(card) || !isCardTypeValid)
                    {
                        isCardValid = false;
                        break;
                    }

                    user.Cards.Add(card);
                }

                if (!IsValid(user) || !isCardValid || user.Cards.Count == 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                validUsers.Add(user);

                result.AppendLine(string.Format(
                    SuccessfullyImportedUser,
                    user.Username,
                    user.Cards.Count));
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var serializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));
            var purchaseDtos = (ImportPurchasesDto[])serializer.Deserialize(reader);

            var validPurchases = new List<Purchase>();
            var result = new StringBuilder();

            foreach (var purchaseDto in purchaseDtos)
            {
                var isPurchaseTypeValid = Enum.TryParse(purchaseDto.Type, out PurchaseType type);
                var isGameValid = context.Games.Any(g => g.Name == purchaseDto.Title);
                var isCardValid = context.Cards.Any(c => c.Number == purchaseDto.Card);

                var purchase = new Purchase
                {
                    Type = type,
                    ProductKey = purchaseDto.Key,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                purchase.Game = game;
                purchase.Card = card;

                if (!IsValid(purchase) || !isPurchaseTypeValid || !isGameValid || !isCardValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var cardUserName = context.Cards
                    .Where(c => c.Number == purchaseDto.Card)
                    .Select(c => c.User.Username)
                    .FirstOrDefault();

                validPurchases.Add(purchase);

                result.AppendLine(string.Format(
                    SuccessfullyImportedPurchase,
                    purchase.Game.Name,
                    cardUserName));
            }

            context.Purchases.AddRange(validPurchases);
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