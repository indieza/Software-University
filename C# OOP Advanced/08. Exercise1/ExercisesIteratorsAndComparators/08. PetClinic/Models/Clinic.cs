namespace _08.PetClinic.Models
{
    using System;
    using System.Linq;

    public class Clinic
    {
        public Clinic(string name, int roomCount)
        {
            if (roomCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.Name = name;
            this.Rooms = new Room[roomCount];

            for (int i = 0; i < this.Rooms.Length; i++)
            {
                this.Rooms[i] = new Room();
            }
        }

        public string Name { get; private set; }

        private Room[] Rooms { get; set; }

        public bool Add(Pet pet)
        {
            int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;

            if (!this.HasEmptyRooms())
            {
                return false;
            }

            int steps = 1;
            int i = centerId;

            for (int j = 0; j < this.Rooms.Length; j++)
            {
                if (this.Rooms[i].SickPet is null)
                {
                    this.Rooms[i].SickPet = pet;
                    return true;
                }

                if (i >= centerId)
                {
                    i = centerId - steps;
                }
                else
                {
                    i = centerId + steps;
                    steps++;
                }
            }

            return false;
        }

        public bool Release()
        {
            int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;

            for (int i = centerId; i < this.Rooms.Length; i++)
            {
                if (this.Rooms[i].SickPet != null)
                {
                    this.Rooms[i].SickPet = null;
                    return true;
                }
            }

            for (int i = 0; i < centerId; i++)
            {
                if (this.Rooms[i].SickPet != null)
                {
                    this.Rooms[i].SickPet = null;
                    return true;
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.Rooms.Any(r => r.SickPet is null);
        }

        public void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.Rooms.ToList()));
        }

        public void Print(int roomId)
        {
            Console.WriteLine(this.Rooms[roomId - 1].ToString());
        }
    }
}