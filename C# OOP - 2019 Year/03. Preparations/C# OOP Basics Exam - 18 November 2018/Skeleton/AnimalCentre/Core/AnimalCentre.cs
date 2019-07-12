namespace AnimalCentre.Core
{
    using global::AnimalCentre.Constraints;
    using global::AnimalCentre.Core.Contracts;
    using global::AnimalCentre.Models;
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre : IAnimalCentre
    {
        private readonly Hotel hotel;
        private readonly Dictionary<string, IProcedure> procedures;
        private readonly Dictionary<string, List<IAnimal>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();
            this.procedures = new Dictionary<string, IProcedure>
            {
                {"Chip", new Chip() },
                {"DentalCare", new DentalCare() },
                {"Fitness", new Fitness() },
                {"NailTrim", new NailTrim() },
                {"Play", new Play() },
                {"Vaccinate", new Vaccinate() }
            };
        }

        public string Adopt(string animalName, string owner)
        {
            CheckAnimal(animalName);
            IAnimal animal = this.hotel.Animals[animalName];

            this.hotel.Adopt(animal.Name, owner);

            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<IAnimal>());
            }
            if (animal.IsAdopt == true)
            {
                this.adoptedAnimals[owner].Add(animal);
            }

            if (animal.IsChipped == false)
            {
                return $"{owner} adopted animal without chip";
            }
            else
            {
                return $"{owner} adopted animal with chip";
            }
        }

        private void CheckAnimal(string animalName)
        {
            if (!this.hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(ExceptionsMessages.AnimalDoesNotExist, animalName));
            }
        }

        public string Chip(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["Chip"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} had chip procedure";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["DentalCare"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} had dental care procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["Fitness"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} had fitness procedure";
        }

        public string History(string type)
        {
            string result = string.Empty;

            switch (type)
            {
                case "Chip":
                    result = this.procedures["Chip"].History();
                    break;

                case "DentalCare":
                    result = this.procedures["DentalCare"].History();
                    break;

                case "Fitness":
                    result = this.procedures["Fitness"].History();
                    break;

                case "NailTrim":
                    result = this.procedures["NailTrim"].History();
                    break;

                case "Play":
                    result = this.procedures["Play"].History();
                    break;

                case "Vaccinate":
                    result = this.procedures["Vaccinate"].History();
                    break;

                default:
                    break;
            }

            return result;
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["NailTrim"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["Play"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = null;

            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;

                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;

                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;

                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;

                default:
                    break;
            }

            this.hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckAnimal(name);

            this.procedures["Vaccinate"].DoService(this.hotel.Animals[name], procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string PrintAdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.adoptedAnimals.OrderBy(k => k.Key))
            {
                sb.AppendLine($"--Owner: {item.Key}");
                List<string> names = new List<string>();

                foreach (var animal in item.Value)
                {
                    names.Add(animal.Name);
                }

                sb.AppendLine($"    - Adopted animals: {string.Join(" ", names)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}