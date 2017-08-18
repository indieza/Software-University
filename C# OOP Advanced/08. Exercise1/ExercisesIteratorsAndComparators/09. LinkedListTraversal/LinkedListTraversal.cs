namespace _09.LinkedListTraversal
{
    using System;
    using System.Text;

    internal class LinkedListTraversal
    {
        private static void Main()
        {
            var linkedList = new LinkedList<int>();
            var countOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCommands; i++)
            {
                var tokens = Console.ReadLine().Split();
                var cmd = tokens[0];

                switch (cmd)
                {
                    case "Add":
                        var elementToAdd = int.Parse(tokens[1]);
                        linkedList.Add(elementToAdd);
                        break;

                    case "Remove":
                        var elementToRemove = int.Parse(tokens[1]);
                        linkedList.Remove(elementToRemove);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            var sb = new StringBuilder();

            foreach (var element in linkedList)
            {
                sb.Append($"{element} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}