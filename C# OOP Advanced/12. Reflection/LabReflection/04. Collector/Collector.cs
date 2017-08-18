namespace _04.Collector
{
    using System;

    internal class Collector
    {
        private static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}