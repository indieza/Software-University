using System;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (ArgumentException arg)
            {
                this.writer.StoreMessage(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        this.gameController.ProduceSummary();
        this.writer.WriteLine(this.writer.StoredMessage());
    }
}