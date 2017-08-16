namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager ioManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            InputReader reader =  new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
