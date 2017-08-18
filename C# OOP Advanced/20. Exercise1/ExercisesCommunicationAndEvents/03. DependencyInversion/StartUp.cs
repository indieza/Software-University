using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>
        {
            {
                '+', new AdditionStrategy()
            },
            {
                '-', new SubtractionStrategy()
            },
            {
                '*', new MultiplyStrategy()
            },
            {
                '/', new DivideStrategy()
            }
        };

        PrimitiveCalculator calc = new PrimitiveCalculator(strategies['+'], strategies);
        string[] input = Console.ReadLine().Split();
        while (input[0] != "End")
        {
            if (input[0] == "mode")
            {
                calc.ChangeStrategy(char.Parse(input[1]));
            }
            else
            {
                Console.WriteLine(calc.PerformCalculation(int.Parse(input[0]), int.Parse(input[1])));
            }

            input = Console.ReadLine().Split();
        }
    }
}