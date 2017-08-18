using System;

namespace _08.CustomListSorter
{
    public class CommandInterpretator
    {
        private CustomList<string> myList = new CustomList<string>();

        public void ParseCommand(string input)
        {
            var tokens = input.Split(' ');
            var cmd = tokens[0];

            switch (cmd)
            {
                case "Add":
                    var element = tokens[1];
                    myList.Add(element);
                    break;

                case "Remove":
                    var index = int.Parse(tokens[1]);
                    myList.Remove(index);
                    break;

                case "Contains":
                    element = tokens[1];
                    Console.WriteLine(myList.Contains(element));
                    break;

                case "Swap":
                    var firstIndex = int.Parse(tokens[1]);
                    var secondIndex = int.Parse(tokens[2]);
                    myList.Swap(firstIndex, secondIndex);
                    break;

                case "Greater":
                    element = tokens[1];
                    Console.WriteLine(myList.CountGreaterThan(element));
                    break;

                case "Max":
                    Console.WriteLine(myList.Max());
                    break;

                case "Min":
                    Console.WriteLine(myList.Min());
                    break;

                case "Print":
                    var listForPrint = myList.GetList();
                    foreach (var item in listForPrint)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "Sort":
                    myList = Sorter<string>.Sort(myList);
                    break;
            }
        }
    }
}