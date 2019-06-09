using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Hospital
{
    public class Hospital
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            List<Patient> patients = new List<Patient>();

            while (line != "Output")
            {
                string[] commandItems = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string department = commandItems[0];
                string doctorName = commandItems[1] + " " + commandItems[2];
                string patientName = commandItems[3];
                int room = patients.Count(p => p.Department == department) / 3 + 1;

                Patient currentPatient = new Patient(department, doctorName, patientName, room);
                patients.Add(currentPatient);

                line = Console.ReadLine();
            }

            string[] searchItems = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (searchItems.Length == 1)
            {
                string searchDepartment = searchItems[0];
                foreach (var patient in patients.Where(p => p.Department == searchDepartment))
                {
                    Console.WriteLine(patient.PatientName);
                }
            }
            else
            {
                string searchDepartment = searchItems[0];
                string searchRoom = searchItems[1];

                if (int.TryParse(searchRoom, out int room))
                {
                    foreach (Patient patient in patients.Where(p => p.Department == searchDepartment)
                        .Where(p => p.Room == room)
                        .OrderBy(p => p.PatientName))
                    {
                        Console.WriteLine(patient.PatientName);
                    }
                }
                else
                {
                    string firstName = searchItems[0];
                    string lastName = searchItems[1];
                    string searchDoctorName = firstName + " " + lastName;

                    foreach (Patient patient in patients.Where(p => p.DoctorName == searchDoctorName)
                        .OrderBy(p => p.PatientName))
                    {
                        Console.WriteLine(patient.PatientName);
                    }
                }
            }
        }
    }

    public class Patient
    {
        public Patient(string department, string doctorName, string patientName, int room)
        {
            this.Department = department;
            this.PatientName = patientName;
            this.DoctorName = doctorName;
            this.Room = room;
        }

        public string Department { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public int Room { get; set; }
    }
}