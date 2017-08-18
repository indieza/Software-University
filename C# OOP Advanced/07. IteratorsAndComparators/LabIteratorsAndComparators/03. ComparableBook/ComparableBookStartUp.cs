namespace _03.ComparableBook
{
    using System;

    internal class ComparableBookStartUp
    {
        private static void Main()
        {
            var bookOne = new Book("Animal Farm", 2003, "George Orwell");
            var bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            var bookThree = new Book("The Documents in the Case", 1930);

            var libraryOne = new Library();
            var libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}