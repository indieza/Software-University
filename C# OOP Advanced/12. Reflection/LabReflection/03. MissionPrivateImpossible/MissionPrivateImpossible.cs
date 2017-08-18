namespace _03.MissionPrivateImpossible
{
    using System;

    internal class MissionPrivateImpossible
    {
        private static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}