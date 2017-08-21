using System;
using System.Text;

public class Engine : IEngine
{
    public void Run()
    {
        ConsoleReader consoleReader = new ConsoleReader();
        ConsoleWriter consoleWriter = new ConsoleWriter();

        var input = consoleReader.ReadLine();
        var gameController = new GameController();

        var result = new StringBuilder();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                gameController.ProcessCommand(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }
            input = consoleReader.ReadLine();
        }

        gameController.ProduceSummury();
        consoleWriter.WriteLine(result.ToString());
    }
}