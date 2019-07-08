namespace MilitaryElite
{
    public class LieutenantGeneralFactory
    {
        public LieutenantGeneral CreateLieutenantGeneral(string[] args)
        {
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);

            LieutenantGeneral soldier = new LieutenantGeneral(id, firstName, lastName, salary);

            return soldier;
        }
    }
}