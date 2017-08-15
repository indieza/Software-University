namespace _9.StudentsEnrolled
{
    using System;
    using System.Linq;

    internal class StudentsEnrolled
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                string[] nums = line.Split(' ');

                if (nums[0].EndsWith("14") || nums[0].EndsWith("15"))
                {
                    Console.WriteLine(string.Join(" ", nums.Skip(1).ToList()));
                }

                line = Console.ReadLine();
            }
        }
    }
}