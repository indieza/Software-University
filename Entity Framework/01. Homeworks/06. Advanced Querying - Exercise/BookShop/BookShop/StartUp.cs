namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(GetGoldenBooks(new BookShopContext()));
            //using (var db = new BookShopContext())
            //{
            //    DbInitializer.ResetDatabase(db);
            //}
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var age = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(b => b.AgeRestriction == age)
                .OrderBy(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.EditionType,
                    b.Copies,
                    b.BookId,
                    b.Title
                })
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.Price,
                    b.Title
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.ReleaseDate,
                    b.BookId,
                    b.Title
                })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}