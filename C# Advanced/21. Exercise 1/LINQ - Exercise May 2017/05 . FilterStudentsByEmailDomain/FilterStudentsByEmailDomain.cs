namespace _5.FilterStudentsByEmailDomain
{
    using System;

    internal class FilterStudentsByEmailDomain
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                if (line.EndsWith("@gmail.com"))
                {
                    string[] studInfo = line.Split(' ');
                    Console.WriteLine(studInfo[0] + " " + studInfo[1]);
                }

                line = Console.ReadLine();
            }
        }
    }
}