namespace _02._BookShop
{
    using System;
    using System.Text;

    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            set
            {
                if (char.IsDigit(value.Split()[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
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