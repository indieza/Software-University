using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    internal class Hospital
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            List<Patient> patients = new List<Patient>();

            while (line != "Output")
            {
                string[] items = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = items[0];
                string doctor = items[1] + " " + items[2];
                string name = items[3];

                int room = patients.Count(p => p.Department == department) / 3 + 1;

                patients.Add(new Patient(department, doctor, name, room));

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                string[] items = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (items.Length == 1)
                {
                    foreach (Patient patient in patients.Where(p => p.Department == items[0]))
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else
                {
                    int index = 0;

                    if (int.TryParse(items[1], out index))
                    {
                        foreach (Patient patient in patients.Where(p => p.Department == items[0] && p.Room == int.Parse(items[1])).OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                    else
                    {
                        foreach (Patient patient in patients.Where(p => p.Doctor == items[0] + " " + items[1]).OrderBy(p => p.Name))
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }

                line = Console.ReadLine();
            }
        }
    }

    public class Patient
    {
        public Patient(string department, string doctor, string name, int room)
        {
            this.Department = department;
            this.Doctor = doctor;
            this.Name = name;
            this.Room = room;
        }

        public string Department { get; set; }

        public string Doctor { get; set; }

        public string Name { get; set; }

        public int Room { get; set; }
    }
}