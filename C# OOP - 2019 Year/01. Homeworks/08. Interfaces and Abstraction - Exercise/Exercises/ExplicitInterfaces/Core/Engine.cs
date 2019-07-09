namespace ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly List<IPerson> citizens;
        private readonly PersonFactory personFactory;

        public Engine()
        {
            this.citizens = new List<IPerson>();
            this.personFactory = new PersonFactory();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] args = line.Split();

                IPerson citizen = this.personFactory.MakeCitizen(args);
                this.citizens.Add(citizen);

                line = Console.ReadLine();
            }

            foreach (var citizen in this.citizens)
            {
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}