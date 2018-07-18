namespace BookShop
{
    using BookShop.Data;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var capitalizedCommand = CapitalizeCommand(command);
            var commandType = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), capitalizedCommand);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == commandType)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        public static string CapitalizeCommand(string command)
        {
            return char.ToUpper(command[0]) + command.Substring(1).ToLower();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenEditionBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenEditionBooks);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return result.ToString().Trim();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var result = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var titles = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.ToLower())
                .ToList();

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => titles.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            var result = string.Join(Environment.NewLine, authors);

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsBooks = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            var result = new StringBuilder();

            foreach (var author in authorsBooks)
            {
                result.AppendLine($"{author.Name} - {author.TotalCopies}");
            }

            return result.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name);

            var result = new StringBuilder();

            foreach (var category in categoriesProfit)
            {
                result.AppendLine($"{category.Name} ${category.Profit}");
            }

            return result.ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                             .Select(b => b.Book)
                             .OrderByDescending(b => b.ReleaseDate)
                             .Take(3)
                             .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in mostRecentBooks)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var b in category.Books)
                {
                    result.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var result = 0;

            var booksToDelete = context.Books
                .Where(b => b.Copies < 4200);

            foreach (var b in booksToDelete)
            {
                result++;
                context.Remove(b);
            }

            context.SaveChanges();
            return result;
        }
    }
}