namespace FilterByAge
{
    using System;
    using System.Collections.Generic;

    internal class FilterByAge
    {
        private static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> studentsWithAge = new Dictionary<string, int>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                studentsWithAge.Add(input[0], int.Parse(input[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> ageChecker = CheckAge(condition, age);
            Action<KeyValuePair<string, int>> printer = CheckWhatToPrint(format);

            foreach (KeyValuePair<string, int> student in studentsWithAge)
            {
                if (ageChecker(student.Value))
                {
                    printer(student);
                }
            }
        }

        private static Func<int, bool> CheckAge(string condition, int age)
        {
            if (condition.Equals("younger"))
            {
                return x => x < age;
            }

            if (condition.Equals("older"))
            {
                return x => x > age;
            }

            return null;
        }

        private static Action<KeyValuePair<string, int>> CheckWhatToPrint(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");

                case "age":
                    return person => Console.WriteLine($"{person.Value}");

                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");

                default: return null;
            }
        }
    }
}