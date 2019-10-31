using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        private static void Main()
        {
            var db = new SalesContext();
            db.Database.EnsureCreated();
        }
    }
}