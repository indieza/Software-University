using BashSoft.Contracts;

namespace BashSoft
{
    class BashSoftProgram
    {
        private static void Main(string[] args)
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IInputReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}