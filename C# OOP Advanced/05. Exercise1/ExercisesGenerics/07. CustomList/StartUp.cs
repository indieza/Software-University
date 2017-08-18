using System;

namespace _07.CustomList
{
    internal class StartUp
    {
        private static void Main()
        {
            var interpretator = new CommandInterpretator();

            var input = Console.ReadLine();
            while (input != "END")
            {
                interpretator.ParseCommand(input);
                input = Console.ReadLine();
            }
        }
    }
}