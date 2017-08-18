using System;

namespace _03.GenericScale
{
    internal class GenericScale
    {
        private static void Main()
        {
            var scale = new Scale<int>(2, 3);
            Console.WriteLine(scale.GetHavier());
        }
    }
}