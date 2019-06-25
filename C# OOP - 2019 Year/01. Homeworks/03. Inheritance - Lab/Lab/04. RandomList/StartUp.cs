using System;

namespace CustomRandomList
{
    public class StartUp
    {
        private static void Main()
        {
            RandomList randomList = new RandomList { "1", "2", "3", "4", "5" };
            Console.WriteLine(randomList.RandomString());
        }
    }
}