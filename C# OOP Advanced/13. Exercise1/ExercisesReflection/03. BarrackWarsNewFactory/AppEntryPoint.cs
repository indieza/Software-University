namespace _03.BarrackWarsNewFactory
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;

    internal class AppEntryPoint
    {
        private static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}