using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    public class KeyRevolver
    {
        private static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> locks = Console.ReadLine().Split().Select(int.Parse).ToList();
            int intelligence = int.Parse(Console.ReadLine());

            int shoots = 0;
            int bulletsShoot = 0;

            while (bullets.Count != 0 && locks.Count != 0)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks[0];

                if (currentBullet > currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.RemoveAt(0);
                }

                shoots++;
                bulletsShoot++;

                if (shoots == gunBarrelSize && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    shoots = 0;
                }
            }

            if (locks.Count == 0)
            {
                int price = intelligence - bulletsShoot * bulletPrice;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${price}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}