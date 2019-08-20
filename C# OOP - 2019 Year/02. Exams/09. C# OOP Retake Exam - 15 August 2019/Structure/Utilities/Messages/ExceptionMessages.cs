using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidAstronautName = "Astronaut name cannot be null or empty.";

        public const string InvalidOxygen = "Cannot create Astronaut with negative oxygen!";

        public const string InvalidPlanetName = "Invalid name!";

        public const string InvalidAstronautType = "Astronaut type doesn't exists!";

        public const string InvalidRetiredAstronaut = "Astronaut {0} doesn't exists!";

        public const string InvalidAstronautCount = "You need at least one astronaut to explore the planet!";




    }
}
