namespace _4.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SortStudents
    {
        private static void Main()
        {
            List<Student> students = new List<Student>();

            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                string[] names = line.Split(' ');
                students.Add(new Student { FirstName = names[0], LastName = names[1] });
                line = Console.ReadLine();
            }

            foreach (var item in students.OrderBy(x => x.LastName).ThenByDescending(x => x.FirstName))
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }

    internal class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}