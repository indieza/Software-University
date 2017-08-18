using System;
using EventImplementation;

public class StartUp
{
    public static void Main(string[] args)
    {
        Dispatcher dispacher = new Dispatcher();
        Handler handler = new Handler();

        dispacher.NameChange += handler.OnDispatcherNameChange;

        string name = Console.ReadLine();

        while (name != "End")
        {
            dispacher.Name = name;
            name = Console.ReadLine();
        }
    }
}