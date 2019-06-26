namespace _02._BookShop
{
    using System.Text;

    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price)
            : base(title, author, price)
        {
        }

        public override decimal Price
        {
            get => base.Price * 1.3m;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Author: {this.Author}");
            sb.AppendLine($"Price: {this.Price:F2}");

            return sb.ToString().TrimEnd();
        }
    }
}