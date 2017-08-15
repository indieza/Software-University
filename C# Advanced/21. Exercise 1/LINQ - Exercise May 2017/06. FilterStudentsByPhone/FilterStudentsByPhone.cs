namespace _6.FilterStudentsByPhone
{
    using System;

    internal class FilterStudentsByPhone
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                string[] studInfo = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (studInfo[2].StartsWith("02") || studInfo[2].StartsWith("+3592"))
                {
                    Console.WriteLine(studInfo[0] + " " + studInfo[1]);
                }

                line = Console.ReadLine();
            }
        }
    }
}