namespace _02.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CollectionStartUp
    {
        private static void Main()
        {
            IList<string> createCommand = Console.ReadLine().Split().ToList();

            ListyIterator<string> listyIterator;

            if (createCommand.Count > 1)
            {
                var items = createCommand.Skip(1).ToList();
                listyIterator = new ListyIterator<string>(items);
            }
            else
            {
                listyIterator = new ListyIterator<string>();
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        Console.WriteLine(listyIterator.Print());
                        break;

                    case "PrintAll":
                        try
                        {
                            IEnumerable<string> people = listyIterator.PrintAll();
                            Console.WriteLine(string.Join(" ", people));
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}