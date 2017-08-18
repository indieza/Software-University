using System;

namespace _03.Mankind
{
    internal class Mankind
    {
        private static void Main()
        {
            try
            {
                string[] firstLineItems = Console.ReadLine().Split();
                string firstNameStudent = firstLineItems[0];
                string lastNameStudent = firstLineItems[1];
                string faculty = firstLineItems[2];

                string[] secondLineItems = Console.ReadLine().Split();
                string firstNameWorker = secondLineItems[0];
                string lastNameWorker = secondLineItems[1];
                double weeklySalary = double.Parse(secondLineItems[2]);
                double workingHours = double.Parse(secondLineItems[3]);

                Student student = new Student(firstNameStudent, lastNameStudent, faculty);

                Worker worker = new Worker(firstNameWorker, lastNameWorker, weeklySalary, workingHours);

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}