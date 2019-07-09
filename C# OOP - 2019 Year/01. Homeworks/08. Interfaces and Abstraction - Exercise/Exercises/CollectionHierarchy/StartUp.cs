using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        private static void Main()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            List<int> result = new List<int>();

            string[] items = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < 3; i++)
            {
                foreach (var item in items)
                {
                    switch (i)
                    {
                        case 0:
                            result.Add(addCollection.Add(item));
                            break;

                        case 1:
                            result.Add(addRemoveCollection.Add(item));
                            break;

                        case 2:
                            result.Add(myList.Add(item));
                            break;
                    }
                }

                Console.WriteLine(string.Join(" ", result));
                result.Clear();
            }

            int removeCount = int.Parse(Console.ReadLine());

            RemoveItem(removeCount, addRemoveCollection);
            RemoveItem(removeCount, myList);
        }

        private static void RemoveItem(int count, IAddRemoveCollection collection)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                result.Add(collection.Remove());
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}