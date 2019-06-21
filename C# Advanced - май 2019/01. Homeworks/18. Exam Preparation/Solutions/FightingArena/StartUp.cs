using System;

namespace FightingArena
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Creates arena
            Arena arena = new Arena("Armeec");

            //Creates stats
            Stat firstGlariatorStat = new Stat(20, 25, 35, 14, 48);
            Stat secondGlariatorStat = new Stat(40, 40, 40, 40, 40);
            Stat thirdGlariatorStat = new Stat(20, 25, 35, 14, 48);

            //Creates weapons
            Weapon firstGlariatorWeapon = new Weapon(5, 28, 100);
            Weapon secondGlariatorWeapon = new Weapon(5, 28, 100);
            Weapon thirdGlariatorWeapon = new Weapon(50, 50, 50);

            //Creates gladiators
            Gladiator firstGladiator = new Gladiator("Stoyan", firstGlariatorStat, firstGlariatorWeapon);
            Gladiator secondGladiator = new Gladiator("Pesho", secondGlariatorStat, secondGlariatorWeapon);
            Gladiator thirdGladiator = new Gladiator("Gosho", thirdGlariatorStat, thirdGlariatorWeapon);

            //Adds gladiators to arena
            arena.Add(firstGladiator);
            arena.Add(secondGladiator);
            arena.Add(thirdGladiator);

            //Prints gladiators count at the arena
            Console.WriteLine(arena.Count);

            //Gets strongest gladiator and print him
            Gladiator strongestGladiator = arena.GetGladitorWithHighestTotalPower();
            Console.WriteLine(strongestGladiator);

            //Gets gladiator with the strongest weapon and print him
            Gladiator bestWeaponGladiator = arena.GetGladitorWithHighestWeaponPower();
            Console.WriteLine(bestWeaponGladiator);

            //Gets gladiator with the strongest stat and print him
            Gladiator bestStatGladiator = arena.GetGladitorWithHighestStatPower();
            Console.WriteLine(bestStatGladiator);

            //Removes gladiator
            arena.Remove("Gosho");

            //Prints gladiators count at the arena
            Console.WriteLine(arena.Count);

            //Prints the arena
            Console.WriteLine(arena);
        }
    }
}
