using FootballTeamGenerator.Core;
using System;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        private static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}