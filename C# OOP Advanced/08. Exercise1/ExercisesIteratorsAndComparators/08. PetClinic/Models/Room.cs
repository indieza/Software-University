namespace _08.PetClinic.Models
{
    public class Room
    {
        public Pet SickPet { get; set; }

        public override string ToString()
        {
            if (this.SickPet is null)
            {
                return "Room empty";
            }

            return this.SickPet.ToString();
        }
    }
}