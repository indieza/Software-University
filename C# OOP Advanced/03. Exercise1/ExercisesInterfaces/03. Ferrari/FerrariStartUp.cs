using System;

internal class FerrariStartUp
{
    private static void Main()
    {
        string name = Console.ReadLine();
        IFerrari ferrari = new Ferrari(name);
        Console.WriteLine(ferrari.ToString());
    }
}