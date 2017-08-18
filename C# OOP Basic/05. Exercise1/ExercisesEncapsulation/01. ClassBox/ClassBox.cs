using System;
using System.Reflection;

namespace _01.ClassBox
{
    internal class ClassBox
    {
        private static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
            decimal l = decimal.Parse(Console.ReadLine());
            decimal w = decimal.Parse(Console.ReadLine());
            decimal h = decimal.Parse(Console.ReadLine());

            Box box = new Box(l, w, h);
            Console.WriteLine(box.ToString());
        }
    }
}