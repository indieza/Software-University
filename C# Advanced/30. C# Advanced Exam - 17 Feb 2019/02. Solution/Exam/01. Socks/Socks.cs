using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    public class Socks
    {
        private static void Main()
        {
            List<int> leftSocks = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> rightSocks = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> pairs = new List<int>();

            while (leftSocks.Count != 0 && rightSocks.Count != 0)
            {
                int leftLastSock = leftSocks[leftSocks.Count - 1];
                int rightFirstSock = rightSocks[0];

                if (leftLastSock == rightFirstSock)
                {
                    rightSocks.RemoveAt(0);
                    leftSocks[leftSocks.Count - 1]++;
                }
                else if (rightFirstSock > leftLastSock)
                {
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                }
                else if (leftLastSock > rightFirstSock)
                {
                    pairs.Add(leftLastSock + rightFirstSock);
                    leftSocks.RemoveAt(leftSocks.Count - 1);
                    rightSocks.RemoveAt(0);
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}