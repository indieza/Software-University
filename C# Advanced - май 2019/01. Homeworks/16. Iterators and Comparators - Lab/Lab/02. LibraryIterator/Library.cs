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
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public bool MoveNext() => ++currentIndex < this.books.Count;

            public void Reset()
            {
                this.currentIndex = -1;
            }

            object IEnumerator.Current => Current;

            public Book Current => this.books[this.currentIndex];

            public void Dispose()
            {
            }
        }
    }
}