namespace _08.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var clinics = new List<Clinic>();
            var pets = new List<Pet>();

            for (int j = 0; j < n; j++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Create")
                {
                    if (input[1] == "Pet")
                    {
                        var petName = input[2];
                        var petAge = int.Parse(input[3]);
                        var petKind = input[4];
                        var pet = new Pet(petName, petAge, petKind);
                        pets.Add(pet);
                    }
                    else
                    {
                        var clinicName = input[2];
                        var roomsCount = int.Parse(input[3]);
                        if (roomsCount % 2 == 0)
                        {
                            Console.WriteLine("Invalid Operation!");
                        }
                        else
                        {
                            var clinic = new Clinic(clinicName, roomsCount);
                            clinics.Add(clinic);
                        }
                    }
                }
                else if (input[0] == "Add")
                {
                    var currentPet = pets.FirstOrDefault(x => x.Name == input[1]);
                    var currentClinic = clinics.FirstOrDefault(x => x.Name == input[2]);
                    var currentClinicIndex = clinics.IndexOf(currentClinic);
                    var isAdded = currentClinic.Add(clinics, currentPet, currentClinicIndex);
                    if (isAdded)
                    {
                        pets.Remove(currentPet);
                    }
                    Console.WriteLine(isAdded);
                }
                else if (input[0] == "Release")
                {
                    var clinicName = input[1];
                    var currentClinic = clinics.FirstOrDefault(x => x.Name == clinicName);
                    var currentClinicIndex = clinics.IndexOf(currentClinic);
                    Console.WriteLine(currentClinic.Release(clinics, currentClinicIndex));
                }
                else if (input[0] == "HasEmptyRooms")
                {
                    var currentClinic = clinics.FirstOrDefault(x => x.Name == input[1]);
                    var currentClinicIndex = clinics.IndexOf(currentClinic);
                    Console.WriteLine(currentClinic.HasEmptyRooms(clinics, currentClinicIndex));
                }
                else if (input[0] == "Print")
                {
                    var currentClinic = clinics.FirstOrDefault(x => x.Name == input[1]);
                    if (input.Length == 2)
                    {
                        Console.WriteLine(currentClinic);
                    }
                    else
                    {
                        var result = currentClinic.Print(int.Parse(input[2]) - 1);
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}