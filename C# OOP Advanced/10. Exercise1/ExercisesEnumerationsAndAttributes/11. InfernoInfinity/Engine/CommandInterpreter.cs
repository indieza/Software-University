using System;
using System.Linq;

public class CommandInterpreter
{
    private readonly Repository repository = new Repository();

    public void StartReadingCommands()
    {
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine();
            var tokens = input.Split(';');
            var cmd = tokens[0];
            var arguments = tokens.Skip(1).ToList();

            switch (cmd)
            {
                case "Create":
                    this.repository.Create(arguments);
                    break;

                case "Add":
                    this.repository.Add(arguments);
                    break;

                case "Remove":
                    this.repository.Remove(arguments);
                    break;

                case "Print":
                    Console.WriteLine(this.repository.Print(arguments[0]));
                    break;

                case "END":
                    isRunning = false;
                    break;
            }
        }
    }
}