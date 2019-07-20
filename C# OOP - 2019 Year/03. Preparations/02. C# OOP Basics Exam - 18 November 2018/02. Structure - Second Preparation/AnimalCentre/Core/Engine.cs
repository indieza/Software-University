namespace AnimalCentre.Core
{
    using System;

    public class Engine
    {
        private AnimalCentre centre;

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
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "RegisterAnimal":
                            result += this.centre.RegisterAnimal(commandItems[1],
                                commandItems[2],
                                int.Parse(commandItems[3]),
                                int.Parse(commandItems[4]),
                                int.Parse(commandItems[5]));
                            break;

                        case "Chip":
                            result += this.centre.Chip(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "DentalCare":
                            result += this.centre.DentalCare(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "Fitness":
                            result += this.centre.Fitness(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "NailTrim":
                            result += this.centre.NailTrim(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "Play":
                            result += this.centre.Play(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "Vaccinate":
                            result += this.centre.Vaccinate(commandItems[1], int.Parse(commandItems[2]));
                            break;

                        case "Adopt":
                            result += this.centre.Adopt(commandItems[1], commandItems[2]);
                            break;

                        case "History":
                            result += this.centre.History(commandItems[1]);
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().Name == "InvalidOperationException")
                    {
                        Console.WriteLine($"InvalidOperationException: {ex.Message}");
                    }
                    if (ex.GetType().Name == "ArgumentException")
                    {
                        Console.WriteLine($"ArgumentException: {ex.Message}");
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(this.centre.PrintOwners());
        }
    }
}