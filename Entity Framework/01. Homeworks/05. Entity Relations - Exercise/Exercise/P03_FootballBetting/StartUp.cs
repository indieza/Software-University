using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        private static void Main()
        {
            var db = new FootballBettingContext();

            db.Database.EnsureCreated();
        }
    }
}