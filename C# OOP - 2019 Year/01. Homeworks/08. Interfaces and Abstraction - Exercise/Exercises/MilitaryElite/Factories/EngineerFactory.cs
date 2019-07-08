namespace MilitaryElite
{
    public class EngineerFactory
    {
        public Engineer CreateEngineer(string[] args)
        {
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            string corps = args[5];

            Engineer soldier = new Engineer(id, firstName, lastName, salary, corps);

            return soldier;
        }
    }
}