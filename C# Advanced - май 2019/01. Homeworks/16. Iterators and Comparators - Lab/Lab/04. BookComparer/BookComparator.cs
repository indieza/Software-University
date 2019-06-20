namespace IteratorsAndComparators
{
    using System.Collections.Generic;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            return firstBook.Title.CompareTo(secondBook.Title) == 0
                ? secondBook.Year.CompareTo(firstBook.Year)
                : firstBook.Title.CompareTo(secondBook.Title);
        }
    }
}