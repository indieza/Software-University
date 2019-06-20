namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }

        public List<Book> Books { get; }

        public IEnumerator<Book> GetEnumerator()
        {
            return this.Books.Select((t, i) => Books[i]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}