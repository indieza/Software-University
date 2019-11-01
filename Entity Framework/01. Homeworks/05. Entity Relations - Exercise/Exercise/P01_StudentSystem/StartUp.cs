using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class StartUp
    {
        private static void Main()
        {
            var db = new StudentSystemContext();

            db.Database.EnsureCreated();
        }
    }
}