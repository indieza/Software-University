using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        private static void Main()
        {
            //Initialize the repository
            SpaceStation spaceStation = new SpaceStation("Apolo", 10);
            //Initialize entity
            Astronaut astronaut = new Astronaut("Stephen", 40, "Bulgaria");
            //Print Astronaut
            Console.WriteLine(astronaut); //Astronaut: Stephen, 40 (Bulgaria)

            //Add Astronaut
            spaceStation.Add(astronaut);
            //Remove Astronaut
            spaceStation.Remove("Astronaut name"); //false - Check

            Astronaut secondAstronaut = new Astronaut("Mark", 34, "UK");

            //Add Astronaut
            spaceStation.Add(secondAstronaut);

            Astronaut oldestAstronaut = spaceStation.GetOldestAstronaut(); // Astronaut with name Stephen
            Astronaut astronautStephen = spaceStation.GetAstronaut("Stephen"); // Astronaut with name Stephen
            Console.WriteLine(oldestAstronaut); //Astronaut: Stephen, 40 (Bulgaria)
            Console.WriteLine(astronautStephen); //Astronaut: Stephen, 40 (Bulgaria)

            Console.WriteLine(spaceStation.Count); //2

            Console.WriteLine(spaceStation.Report());
            //Astronauts working at Space Station Apolo:
            //Astronaut: Stephen, 40 (Bulgaria)
            //Astronaut: Mark, 34 (UK)
        }
    }
}