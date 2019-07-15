namespace AnimalCentre.Core
{
    using System;

    public class Engine
    {
        private readonly AnimalCentre centre;

        public Engine()
        {
            this.centre = new AnimalCentre();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commandItems = line.Split();
                string command = commandItems[0];

                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(centre.RegisterAnimal(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]),
                                int.Parse(commandItems[4]),
                                int.Parse(commandItems[5])));
                            break;

                        case "Chip":
                            Console.WriteLine(this.centre.Chip(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "Vaccinate":
                            Console.WriteLine(this.centre.Vaccinate(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "Fitness":
                            Console.WriteLine(this.centre.Fitness(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "Play":
                            Console.WriteLine(this.centre.Play(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "DentalCare":
                            Console.WriteLine(this.centre.DentalCare(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "NailTrim":
                            Console.WriteLine(this.centre.NailTrim(commandItems[1], int.Parse(commandItems[2])));
                            break;

                        case "Adopt":
                            Console.WriteLine(this.centre.Adopt(commandItems[1], commandItems[2]));
                            break;

                        case "History":
                            Console.WriteLine(this.centre.History(commandItems[1]));
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name == "InvalidOperationException")
                    {
                        Console.WriteLine("InvalidOperationException: " + ex.Message);
                    }
                    else if (ex.GetType().Name == "ArgumentException")
                    {
                        Console.WriteLine("ArgumentException: " + ex.Message);
                    }
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(this.centre.PrintAdoptedAnimals());
        }
    }
}