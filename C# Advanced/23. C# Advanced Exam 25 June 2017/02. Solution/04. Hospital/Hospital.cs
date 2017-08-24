using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    internal class Hospital
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            List<Patient> list = new List<Patient>();

            while (input != "Output")
            {
                string[] parts = input.Split(' ');

                Patient patient = new Patient
                {
                    Department = parts[0],
                    Doctor = parts[1] + " " + parts[2],
                    Name = parts[3]
                };

                int room = list.Count(s => s.Department == parts[0]) / 3 + 1;

                patient.Room = room;
                list.Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string[] parts = input.Split(' ');

                if (parts.Length == 1)
                {
                    foreach (Patient patient in list.Where(p => p.Department == parts[0]))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else
                {
                    int count;

                    if (int.TryParse(parts[1], out count))
                    {
                        foreach (Patient p in list.Where(p => p.Department == parts[0] && p.Room == count).OrderBy(s => s.Name))
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                    else
                    {
                        foreach (Patient p in list.Where(p => p.Doctor == parts[0] + " " + parts[1]).OrderBy(s => s.Name))
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
    }

    public class Patient
    {
        public string Department { get; set; }

        public string Doctor { get; set; }

        public string Name { get; set; }

        public int Room { get; set; }
    }
}