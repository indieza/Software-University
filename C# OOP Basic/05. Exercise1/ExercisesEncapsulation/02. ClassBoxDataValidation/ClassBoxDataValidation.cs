using System;
using System.Reflection;

namespace _02.ClassBoxDataValidation
{
    internal class ClassBoxDataValidation
    {
        private static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            try
            {
                double l = double.Parse(Console.ReadLine());
                double w = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());

                Box box = new Box(l, w, h);
                Console.WriteLine(box.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}