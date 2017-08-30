using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class ArrangeIntegers
{
    private static void Main()
    {
        List<int> numbers = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        List<string> words = new List<string>(numbers.Count);

        foreach (int number in numbers)
        {
            StringBuilder numberAsWord = new StringBuilder();
            char[] numberAsCharArray = number.ToString().ToCharArray();

            foreach (char symbol in numberAsCharArray)
            {
                switch (symbol)
                {
                    case '0':
                        numberAsWord.Append("zero ");
                        break;

                    case '1':
                        numberAsWord.Append("one ");
                        break;

                    case '2':
                        numberAsWord.Append("two ");
                        break;

                    case '3':
                        numberAsWord.Append("three ");
                        break;

                    case '4':
                        numberAsWord.Append("four ");
                        break;

                    case '5':
                        numberAsWord.Append("five ");
                        break;

                    case '6':
                        numberAsWord.Append("six ");
                        break;

                    case '7':
                        numberAsWord.Append("seven ");
                        break;

                    case '8':
                        numberAsWord.Append("eight ");
                        break;

                    case '9':
                        numberAsWord.Append("nine ");
                        break;
                }
            }

            words.Add(numberAsWord.ToString().Trim());
        }

        words.Sort();

        List<int> result = new List<int>(numbers.Count);

        foreach (string word in words)
        {
            StringBuilder wordAsDigit = new StringBuilder();
            string[] numberAsArray = word.Split();

            foreach (string symbol in numberAsArray)
            {
                switch (symbol)
                {
                    case "zero":
                        wordAsDigit.Append(0);
                        break;

                    case "one":
                        wordAsDigit.Append(1);
                        break;

                    case "two":
                        wordAsDigit.Append(2);
                        break;

                    case "three":
                        wordAsDigit.Append(3);
                        break;

                    case "four":
                        wordAsDigit.Append(4);
                        break;

                    case "five":
                        wordAsDigit.Append(5);
                        break;

                    case "six":
                        wordAsDigit.Append(6);
                        break;

                    case "seven":
                        wordAsDigit.Append(7);
                        break;

                    case "eight":
                        wordAsDigit.Append(8);
                        break;

                    case "nine":
                        wordAsDigit.Append(9);
                        break;
                }
            }

            result.Add(int.Parse(wordAsDigit.ToString()));
        }

        Console.WriteLine(string.Join(", ", result));
    }
}