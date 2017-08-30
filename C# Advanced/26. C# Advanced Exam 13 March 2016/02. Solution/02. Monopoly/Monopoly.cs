using System;
using System.Linq;

internal class Monopoly
{
    private static void Main()
    {
        int[] rowsCols = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int money = 50;
        int turns = 0;
        int hotels = 0;

        for (int row = 0; row < rowsCols[0]; row++)
        {
            char[] items = Console.ReadLine().ToCharArray();

            for (int col = 0; col < rowsCols[1]; col++)
            {
                int index = row % 2 == 0 ? col : items.Length - col - 1;

                switch (items[index])
                {
                    case 'H':
                        hotels++;
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                        money = 0;
                        break;

                    case 'J':
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        money += 2 * hotels * 10;
                        turns += 2;
                        break;

                    case 'S':
                        int columnIndex = row % 2 == 0 ? col : index;
                        int moneyToSpend = Math.Min((columnIndex + 1) * (row + 1), money);
                        money -= moneyToSpend;
                        Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                        break;
                }

                turns++;
                money += hotels * 10;
            }
        }

        Console.WriteLine("Turns " + turns);
        Console.WriteLine("Money " + money);
    }
}