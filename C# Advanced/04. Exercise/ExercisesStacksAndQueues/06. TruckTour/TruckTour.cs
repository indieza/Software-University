namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TruckTour
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int petrolTotal = 0;
            int distanceTotal = 0;

            Queue<int> petrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                petrol.Enqueue(input[0]);
                petrolTotal += input[0];
                distance.Enqueue(input[1]);
                distanceTotal += input[1];
            }

            if (petrolTotal < distanceTotal)
            {
                return;
            }

            petrolTotal = 0;
            distanceTotal = 0;
            int count = 0;
            int index = 0;
            int minIndex = -1;

            while (index < n && count < n)
            {
                petrolTotal += petrol.Peek();
                distanceTotal += distance.Peek();

                if (petrolTotal >= distanceTotal)
                {
                    if (minIndex == -1)
                    {
                        minIndex = index;
                    }

                    count++;
                }
                else
                {
                    petrolTotal = 0;
                    distanceTotal = 0;
                    count = 0;
                    minIndex = -1;
                }

                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
                index++;
            }

            if (minIndex != -1)
            {
                Console.WriteLine(minIndex);
            }
        }
    }
}