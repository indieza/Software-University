namespace _2.StudentsByFirstAndLastName
{
    using System;

    internal class StudentsByFirstAndLastName
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (!line.Equals("END") && !string.IsNullOrWhiteSpace(line))
            {
                string[] names = line.ToLower().Split(' ');
                int min = Math.Min(names[0].Length, names[1].Length);

                for (int i = 0; i < min; i++)
                {
                    if (names[0][i] == names[1][i])
                    {
                        continue;
                    }

                    if (names[0][i] > names[1][i])
                    {
                        break;
                    }

                    Console.WriteLine(line);

                    break;
                }

                line = Console.ReadLine();
            }
        }
    }
}