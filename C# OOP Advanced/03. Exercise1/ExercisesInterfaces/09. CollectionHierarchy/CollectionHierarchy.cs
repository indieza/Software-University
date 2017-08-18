using System;

namespace _09.CollectionHierarchy
{
    internal class CollectionHierarchy
    {
        private static void Main()
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            var elements = Console.ReadLine().Split();

            var addCollectionAddIndexes = String.Empty;
            var addRemoveCollectionAddIndexes = String.Empty;
            var myListAddIndexes = String.Empty;

            int index;
            foreach (var element in elements)
            {
                index = addCollection.Add(element);
                addCollectionAddIndexes += index + " ";

                index = addRemoveCollection.Add(element);
                addRemoveCollectionAddIndexes += index + " ";

                index = myList.Add(element);
                myListAddIndexes += index + " ";
            }

            Console.WriteLine(addCollectionAddIndexes.Trim());
            Console.WriteLine(addRemoveCollectionAddIndexes.Trim());
            Console.WriteLine(myListAddIndexes.Trim());

            var countOfRemoveOperations = int.Parse(Console.ReadLine());

            var addRemoveCollectionRemoveElements = String.Empty;
            var myListAddRemoveElements = String.Empty;

            var elementToRemove = string.Empty;
            for (int i = 0; i < countOfRemoveOperations; i++)
            {
                elementToRemove = addRemoveCollection.Remove();
                addRemoveCollectionRemoveElements += elementToRemove + " ";

                elementToRemove = myList.Remove();
                myListAddRemoveElements += elementToRemove + " ";
            }

            Console.WriteLine(addRemoveCollectionRemoveElements.Trim());
            Console.WriteLine(myListAddRemoveElements.Trim());
        }
    }
}