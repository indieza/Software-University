using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core;
using _03BarracksFactory.Core.Factories;
using _03BarracksFactory.Data;

namespace _03BarracksFactory
{
    public class StartUp
    {
        private static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory factory = new UnitFactory();
            IRunnable run = new Engine(repository, factory);
            run.Run();
        }
    }
}