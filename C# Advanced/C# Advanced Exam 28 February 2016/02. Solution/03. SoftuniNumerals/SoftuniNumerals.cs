using System;
using System.Numerics;

internal class SoftuniNumerals
{
    private static void Main()
    {
        string base5String = ConvertStringToBase5(Console.ReadLine());
        Console.WriteLine(ConvertBase5ToBase10(base5String));
    }

    private static string ConvertStringToBase5(string line)
    {
        string[] digitCodes = { "aa", "aba", "bcc", "cc", "cdc" };

        string result = string.Empty;
        while (line.Length > 0)
        {
            for (int index = 0; index < digitCodes.Length; index++)
            {
                string code = digitCodes[index];

                if (line.StartsWith(code))
                {
                    result += index;
                    line = line.Substring(code.Length);
                    break;
                }
            }
        }

        return result;
    }

    private static BigInteger ConvertBase5ToBase10(string base5String)
    {
        BigInteger result = 0;

        for (int index = 0; index < base5String.Length; index++)
        {
            BigInteger nextDigit = base5String[base5String.Length - 1 - index] - '0';
            result += nextDigit * BigInteger.Pow(5, index);
        }

        return result;
    }
}