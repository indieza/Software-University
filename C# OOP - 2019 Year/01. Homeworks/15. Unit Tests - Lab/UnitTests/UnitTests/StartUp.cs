using System;

namespace UnitTests
{
    public class StartUp

    {
        private static void Main()
        {
            Person person = new Person("Simeon", "Valev", 19);
            Console.WriteLine(person.ToString());
        }
    }
}