using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    public class FashionBoutique
    {
        private static void Main()
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());

            int saveCapacity = 0;
            int racks = 1;
            int count = clothes.Count();

            for (int i = 0; i < count; i++)
            {
                int currentNum = clothes.Peek();

                if (currentNum + saveCapacity <= capacity)
                {
                    saveCapacity += clothes.Pop();
                }
                else
                {
                    saveCapacity = clothes.Pop();
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}