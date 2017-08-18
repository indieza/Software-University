using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return this.books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private int index = 0;
        private IReadOnlyList<Book> books;

        public LibraryIterator(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public Book Current => this.books[this.index];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.index < this.books.Count;
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}