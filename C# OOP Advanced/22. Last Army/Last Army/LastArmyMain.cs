internal class LastArmyMain
{
    private static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IGameController gameController = new GameController(writer);
        Engine engine = new Engine(reader, writer, gameController);
        engine.Run();
    }
}