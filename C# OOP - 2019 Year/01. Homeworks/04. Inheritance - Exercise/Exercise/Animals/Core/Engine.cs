namespace Animals.Core
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            while (true)
            {
                var animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                try
                {
                    string[] animalArgs = Console.ReadLine().Split(" ");
                    string name = animalArgs[0];
                    int age = int.Parse(animalArgs[1]);
                    string gender = animalArgs[2];

                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            this.animals.Add(dog);
                            break;

                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            this.animals.Add(cat);
                            break;

                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            this.animals.Add(frog);
                            break;

                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            this.animals.Add(kitten);
                            break;

                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            this.animals.Add(tomcat);
                            break;

                        default:
                            throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal.ToString().TrimEnd());
            }
        }
    }
}