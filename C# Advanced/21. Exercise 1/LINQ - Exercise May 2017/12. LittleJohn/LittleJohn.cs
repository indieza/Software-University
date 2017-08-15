namespace _12.LittleJohn
{
    using System;
    using System.Text.RegularExpressions;

    internal class LittleJohn
    {
        private static void Main()
        {
            Regex pattern = new Regex(@">>>----->>|>>----->|>----->");

            int[] arrow = new int[3];

            for (int i = 0; i < 4; i++)
            {
                MatchCollection mat = pattern.Matches(Console.ReadLine());

                foreach (Match item in mat)
                {
                    if (item.Value == ">>>----->>")
                    {
                        arrow[2]++;
                    }
                    else if (item.Value == ">>----->")
                    {
                        arrow[1]++;
                    }
                    else
                    {
                        arrow[0]++;
                    }
                }
            }

            int num = int.Parse(string.Join(string.Empty, arrow));
            string bin0 = Convert.ToString(num, 2);
            char[] rever = bin0.ToCharArray();
            Array.Reverse(rever);
            string bin1 = new string(rever);
            Console.WriteLine(Convert.ToInt32(bin0 + bin1, 2));
        }
    }
}