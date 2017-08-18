using System;

namespace _04.FirstAndReserveTeam
{
    internal class FirstAndReserveTeam
    {
        private static void Main()
        {
            var name = Console.ReadLine();
            var lines = int.Parse(Console.ReadLine());
            var team = new Team(name);

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    double.Parse(cmdArgs[3]));
                team.AddPlayer(person);
            }
        }
    }
}