namespace StudentSystem
{
    public class StartUp
    {
        private static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}