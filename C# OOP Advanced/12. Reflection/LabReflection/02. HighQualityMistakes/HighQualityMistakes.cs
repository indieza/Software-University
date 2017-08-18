namespace _02.HighQualityMistakes
{
    using System;

    internal class HighQualityMistakes
    {
        private static void Main()
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}