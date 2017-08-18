namespace _01.Stealer
{
    using System;

    internal class Stealer
    {
        private static void Main()
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}