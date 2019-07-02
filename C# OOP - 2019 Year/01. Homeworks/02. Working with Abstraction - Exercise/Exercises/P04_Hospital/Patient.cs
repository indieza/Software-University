namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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