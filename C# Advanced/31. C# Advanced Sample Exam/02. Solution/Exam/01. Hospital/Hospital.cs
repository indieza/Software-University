using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Hospital
{
    public class Hospital
    {
        private static void Main()
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

    public class Patient
    {
        private string department;
        private string doctor;
        private string patientName;
        private int room;

        public Patient(string department, string doctor, string patientName, int room)
        {
            this.Departmen = department;
            this.Doctor = doctor;
            this.PatientName = patientName;
            this.Room = room;
        }

        public string Departmen
        {
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }

        public string Doctor
        {
            get
            {
                return this.doctor;
            }
            set
            {
                this.doctor = value;
            }
        }

        public string PatientName
        {
            get
            {
                return this.patientName;
            }
            set
            {
                this.patientName = value;
            }
        }

        public int Room
        {
            get
            {
                return this.room;
            }
            set
            {
                this.room = value;
            }
        }
    }
}