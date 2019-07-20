namespace AnimalCentre.Core
{
    using global::AnimalCentre.Contracts;
    using global::AnimalCentre.Models.Animals;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Hotel;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private readonly IHotel hotel;
        private readonly Dictionary<string, IProcedure> procedures;
        private readonly Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure>
            {
                {"Chip", new Chip() },
                {"DentalCare", new DentalCare() },
                {"Fitness", new Fitness() },
                {"NailTrim", new NailTrim() },
                {"Play", new Play() },
                {"Vaccinate", new Vaccinate() }
            };
            this.adoptedAnimals = new Dictionary<string, List<string>>();
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
            return string.Format(ConstantMessages.SuccessfullyRegisteredAnimal, name);
        }

        public string Chip(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Chip"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.ChipAnimal, name);
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Vaccinate"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.VaccinateAnimal, name);
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Fitness"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.FitnessAnimal, name);
        }

        public string Play(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["Play"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.PlayAnimal, name, procedureTime);
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["DentalCare"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.DentalCareAnimal, name);
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckAnimalExist(name);
            IAnimal animal = this.hotel.Animals[name];
            this.procedures["NailTrim"].DoService(animal, procedureTime);
            return string.Format(ConstantMessages.NailTrimAnimal, name, procedureTime);
        }

        public string Adopt(string animalName, string owner)
        {
            CheckAnimalExist(animalName);
            IAnimal animal = this.hotel.Animals[animalName];
            this.hotel.Adopt(animalName, owner);

            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<string>());
            }
            if (animal.IsAdopt == true)
            {
                this.adoptedAnimals[owner].Add(animalName);
            }
            if (animal.IsChipped)
            {
                return string.Format(ConstantMessages.AdoptChippedAnimal, owner);
            }
            else
            {
                return string.Format(ConstantMessages.AdoptNotChippedAnimal, owner);
            }
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

        private void CheckAnimalExist(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AnimalDoesNotExist, name));
            }
        }

        public string PrintOwners()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string owner in this.adoptedAnimals.Keys.OrderBy(k => k))
            {
                sb.AppendLine($"--Owner: {owner}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", this.adoptedAnimals[owner])}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}