namespace _08.PetClinic
{
    using System.Collections.Generic;
    using System.Text;

    public class Clinic
    {
        public Clinic(string name, int rooms)
        {
            Name = name;
            Rooms = new Pet[rooms];
        }

        public string Name { get; set; }

        public Pet[] Rooms { get; set; }

        public bool Add(List<Clinic> clinics, Pet pet,int clinicIndex)
        {
            for (int i = 0; i <= this.Rooms.Length / 2; i++)
            {
                if (clinics[clinicIndex].Rooms[this.Rooms.Length / 2 - i] == null)
                {
                    clinics[clinicIndex].Rooms[this.Rooms.Length / 2 - i] = pet;
                    return true;
                }
                if (clinics[clinicIndex].Rooms[this.Rooms.Length / 2 + i] == null)
                {
                    clinics[clinicIndex].Rooms[this.Rooms.Length / 2 + i] = pet;
                    return true;
                }
            }
            return false;
        }

        public bool Release(List<Clinic> clinics, int index)
        {

            for (int i = this.Rooms.Length / 2; i < this.Rooms.Length; i++)
            {
                if (clinics[index].Rooms[i] != null)
                {
                    clinics[index].Rooms[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < this.Rooms.Length / 2; i++)
            {
                clinics[index].Rooms[i] = null;
                return true;
            }

            return false;
        }

        public bool HasEmptyRooms(List<Clinic> clinics, int index)
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                if (clinics[index].Rooms[i] == null)
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            var clinicInfo = new StringBuilder();
            foreach (var pet in this.Rooms)
            {
                clinicInfo.AppendLine(pet == null ? "Room empty" : $"{pet.Name} {pet.Age} {pet.Kind}");
            }

            return clinicInfo.ToString();
        }

        public string Print(int index)
        {
            return this.Rooms[index] == null
                ? $"Room empty"
                : $"{this.Rooms[index].Name} {this.Rooms[index].Age} {this.Rooms[index].Kind}";
        }
    }
}
