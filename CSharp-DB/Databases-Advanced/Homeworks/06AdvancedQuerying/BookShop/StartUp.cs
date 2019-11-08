namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
        }

        // Problem. 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = new StringBuilder();

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var result = new StringBuilder();

            var bookTitles = context
                .BooksCategories
                .Where(bc => categories
                    .Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParts = date.Split("-");

            var day = int.Parse(dateParts[0]);
            var month = int.Parse(dateParts[1]);
            var year = int.Parse(dateParts[2]);

            var givenDate = new DateTime(year, month, day);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < givenDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.FullName)
                .ToList();

            var result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FullName}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context
                .Books
                .Where(b => b.Title.ToLower()
                    .Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = new StringBuilder();

            foreach (var title in bookTitles)
            {
                result.AppendLine(title);
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.AuthorFullName})");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books
                .Count(b => b.Title.Length > lengthCheck);

        // Problem. 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    BookCopies = a.Books
                        .Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            var result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine($"{author.FirstName} {author.LastName} - {author.BookCopies}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate
                        })
                        .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString().TrimEnd();
        }

        // Problem. 14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem. 15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var removedBooks = books.Count;

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return removedBooks;
        }
    }
}
