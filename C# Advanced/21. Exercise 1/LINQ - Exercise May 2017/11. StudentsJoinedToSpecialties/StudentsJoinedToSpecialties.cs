namespace _11.StudentsJoinedToSpecialties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class StudentsJoinedToSpecialties
    {
        private static void Main()
        {
            List<Specialities> spec = new List<Specialities>();
            List<Person> students = new List<Person>();

            Regex specs = new Regex(@"(.*) (\d+)");
            Regex studs = new Regex(@"(\d+)\s*(.*)");

            GetSpecialities(spec, specs);
            GetStudentsInfo(students, studs);

            List<Result> res = new List<Result>();

            foreach (var item in spec)
            {
                var a = students.Where(x => x.FacNum == item.FacNum);

                foreach (var it in a)
                {
                    res.Add(new Result
                    {
                        Name = it.Name,
                        FacNum = it.FacNum,
                        Speciality = item.Speciality
                    });
                }
            }

            foreach (var item in res.OrderBy(x => x.Name))
            {
                Console.WriteLine("{0} {1} {2}", item.Name, item.FacNum, item.Speciality);
            }
        }

        private static void GetStudentsInfo(List<Person> students, Regex studs)
        {
            string stud = Console.ReadLine();

            while (!stud.Equals("END"))
            {
                Match st = studs.Match(stud);
                string name = st.Groups[2].Value;
                int facNum = int.Parse(st.Groups[1].Value);
                students.Add(new Person() { FacNum = facNum, Name = name });
                stud = Console.ReadLine();
            }
        }

        private static void GetSpecialities(List<Specialities> spec, Regex specs)
        {
            string line = Console.ReadLine();

            while (!line.Equals("Students:"))
            {
                Match spe = specs.Match(line);
                string speciality = spe.Groups[1].Value;
                int facNum = int.Parse(spe.Groups[2].Value);
                spec.Add(new Specialities() { FacNum = facNum, Speciality = speciality });
                line = Console.ReadLine();
            }
        }
    }

    internal class Person
    {
        public int FacNum { get; set; }

        public string Name { get; set; }
    }

    internal class Specialities
    {
        public int FacNum { get; set; }

        public string Speciality { get; set; }
    }

    internal class Result
    {
        public string Name { get; set; }

        public int FacNum { get; set; }

        public string Speciality { get; set; }
    }
}