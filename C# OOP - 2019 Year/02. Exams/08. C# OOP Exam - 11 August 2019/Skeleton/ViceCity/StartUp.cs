using ViceCity.Core;
using ViceCity.Core.Contracts;

namespace ViceCity
{
    public class StartUp
    {
        private IEngine engine;

        private static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}