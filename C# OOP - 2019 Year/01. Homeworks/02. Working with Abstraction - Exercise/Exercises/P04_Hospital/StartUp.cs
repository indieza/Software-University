using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            List<Patient> patients = new List<Patient>();

            string line = Console.ReadLine();

            while (line != "Output")
            {
                string[] items = line.Split();
                string department = items[0];
                string doctor = items[1] + " " + items[2];
                string patientName = items[3];
                int room = patients.Count(p => p.Departmen == department) / 3 + 1;

                patients.Add(new Patient(department, doctor, patientName, room));

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "End")
            {
                string[] items = line.Split();

                if (items.Length == 1)
                {
                    foreach (var patient in patients)
                    {
                        if (patient.Departmen == items[0])
                        {
                            Console.WriteLine(patient.PatientName);
                        }
                    }
                }
                else
                {
                    int count = 0;

                    if (int.TryParse(items[1], out count))
                    {
                        foreach (var patient in patients
                            .Where(p => p.Room == count && p.Departmen == items[0])
                            .OrderBy(p => p.PatientName))
                        {
                            Console.WriteLine(patient.PatientName);
                        }
                    }
                    else
                    {
                        string doctor = items[0] + " " + items[1];

                        foreach (var patient in patients.Where(p => p.Doctor == doctor).OrderBy(p => p.PatientName))
                        {
                            Console.WriteLine(patient.PatientName);
                        }
                    }
                }

                line = Console.ReadLine();
            }
        }
    }
}