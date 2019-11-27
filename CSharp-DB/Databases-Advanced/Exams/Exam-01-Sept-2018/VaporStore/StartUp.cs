namespace VaporStore
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
		    using var context = new VaporStoreDbContext();
		}

		private static void ResetDatabase(VaporStoreDbContext context)
		{
		    context.Database.EnsureDeleted();
		    context.Database.Migrate();

		    var importGamesJson = File.ReadAllText(@".\..\..\..\Datasets\games.json");
		    var gamesResult = Deserializer.ImportGames(context, importGamesJson);

		    var importUsersJson = File.ReadAllText(@".\..\..\..\Datasets\users.json");
		    var usersResult = Deserializer.ImportUsers(context, importUsersJson);

		    var importPurchasesXml = File.ReadAllText(@".\..\..\..\Datasets\purchases.xml");
		    var purchasesResult = Deserializer.ImportPurchases(context, importPurchasesXml);
		}
    	}
}
