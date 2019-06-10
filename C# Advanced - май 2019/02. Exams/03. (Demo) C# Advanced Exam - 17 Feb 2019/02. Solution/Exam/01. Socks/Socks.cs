using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    public class Socks
    {
        private static void Main()
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> rightSocks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> pairs = new List<int>();

            while (leftSocks.Count() != 0 && rightSocks.Count() != 0)
            {
                int currentLeftSock = leftSocks.Peek();
                int currentRightSock = rightSocks.Peek();

                if (currentLeftSock > currentRightSock)
                {
                    pairs.Add(currentLeftSock + currentRightSock);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (currentRightSock > currentLeftSock)
                {
                    leftSocks.Pop();
                }
                else if (currentLeftSock == currentRightSock)
                {
                    rightSocks.Dequeue();
                    leftSocks.Pop();
                    leftSocks.Push(currentLeftSock + 1);
                }
            }

            Console.WriteLine($"{pairs.Max()}");
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}