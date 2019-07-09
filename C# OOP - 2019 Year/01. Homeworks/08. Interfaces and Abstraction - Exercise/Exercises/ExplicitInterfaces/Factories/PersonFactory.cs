namespace ExplicitInterfaces
{
    public class PersonFactory
    {
        public Citizen MakeCitizen(string[] args)
        {
            string name = args[0];
            string country = args[1];
            int age = int.Parse(args[2]);
            Citizen citizen = new Citizen(name, age, country);

            return citizen;
        }
    }
}