using System;

public class StartUp
{
    private static void Main()
    {
        try
        {
            Dummy dummy = new Dummy(-10, 15);
            dummy.GiveExperience();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}