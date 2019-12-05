namespace VaporStore.DataProcessor
{
    	using System;
    	using System.Globalization;
    	using System.IO;
    	using System.Linq;
    	using System.Xml.Serialization;
	
    	using Newtonsoft.Json;
	
    	using Data;
    	using Dto.Export;

    	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            		var genres = context.Genres
            		    .Where(g => genreNames.Contains(g.Name)
            		        && g.Games.Any(g => g.Purchases.Any()))
            		    .Select(genre => new
            		    {
            		        Id = genre.Id,
            		        Genre = genre.Name,
            		        Games = genre.Games
            		            .Where(g => g.Purchases.Any())
            		            .Select(game => new
            		            {
            		                Id = game.Id,
            		                Title = game.Name,
            		                Developer = game.Developer.Name,
            		                Tags = string.Join(", ", game.GameTags
            		                    .Select(gt => gt.Tag.Name)),
            		                Players = game.Purchases.Count
            		            })
            		            .OrderByDescending(game => game.Players)
            		            .ThenBy(game => game.Id),
            		        TotalPlayers = genre.Games.Sum(g => g.Purchases.Count)
            		    })
            		    .OrderByDescending(genre => genre.TotalPlayers)
            		    .ThenBy(genre => genre.Id)
            		    .ToArray();
		
            		var genresJson = JsonConvert.SerializeObject(genres, Formatting.Indented);
		
            		return genresJson;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            		var users = context.Users
            		    .Select(u => new ExportUserDto
            		    {
            		        Username = u.Username,
            		        Purchases = u.Cards
            		            .SelectMany(c => c.Purchases)
            		            .Where(p => p.Type.ToString() == storeType)
            		            .OrderBy(p => p.Date)
            		            .Select(p => new ExportPurchaseDto
            		            {
            		                Card = p.Card.Number,
            		                Cvc = p.Card.Cvc,
            		                Date = p.Date.ToString(@"yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            		                Game = new ExportGameDto
            		                {
            		                    Title = p.Game.Name,
            		                    Genre = p.Game.Genre.Name,
            		                    Price = p.Game.Price
            		                }
            		            })
            		            .ToArray(),
            		        TotalSpent = u.Cards
            		            .SelectMany(c => c.Purchases)
            		            .Where(p => p.Type.ToString() == storeType)
            		            .Sum(p => p.Game.Price)
            		    })
            		    .Where(u => u.Purchases.Any())
            		    .OrderByDescending(u => u.TotalSpent)
            		    .ThenBy(u => u.Username)
            		    .ToArray();

            		using var writer = new StringWriter();
		
            		var ns = new XmlSerializerNamespaces();
            		ns.Add(string.Empty, string.Empty);
		
            		var xmlSerializer = new XmlSerializer(
            		    typeof(ExportUserDto[]),
            		    new XmlRootAttribute("Users"));
            		xmlSerializer.Serialize(writer, users, ns);
		
            		var usersXml = writer.GetStringBuilder();
		
            		return usersXml.ToString().TrimEnd();
		}
	}
}
