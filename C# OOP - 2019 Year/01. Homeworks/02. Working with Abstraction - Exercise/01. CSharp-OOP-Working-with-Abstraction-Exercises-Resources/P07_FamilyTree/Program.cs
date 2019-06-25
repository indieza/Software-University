using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    internal class Program
    {
        public static void Main()
        {
            var nameBirthday = new List<string>();
            var parentChild = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (input.Contains("-"))
                {
                    parentChild.Add(input);
                }
                else
                {
                    nameBirthday.Add(input);
                }
            }

            var mainPersonName = string.Empty;
            var mainPersonBirthday = string.Empty;

            if (nameBirthday[0].Contains('/'))
            {
                mainPersonBirthday = nameBirthday[0];
                mainPersonName = nameBirthday
                   .FirstOrDefault(x => x.Contains(mainPersonBirthday) && x.Length > mainPersonBirthday.Length)
                   .Replace(mainPersonBirthday, "").Trim();
            }
            else
            {
                mainPersonName = nameBirthday[0];
                mainPersonBirthday = nameBirthday.FirstOrDefault(x => x.Contains(mainPersonName) && x.Contains("/"))
                    .Replace(mainPersonName, "").Trim();
            }
            var mainPerson = new Person()
            {
                Name = mainPersonName,
                Birthday = mainPersonBirthday
            };

            foreach (var line in parentChild)
            {
                if (line.Contains(mainPerson.Name) || line.Contains(mainPerson.Birthday))
                {
                    var currentLine = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    if (currentLine[0] == mainPerson.Birthday || currentLine[0] == mainPerson.Name)
                    {
                        var child = new Person();
                        if (currentLine[1].Contains("/"))
                        {
                            var childBirthday = currentLine[1];
                            var childName = nameBirthday.FirstOrDefault(x => x.Contains(childBirthday))
                                .Replace(childBirthday, "").Trim();
                            child = new Person() { Birthday = childBirthday, Name = childName };

                        }
                        else
                        {
                            var childName = currentLine[1];
                            var childBirthday = nameBirthday.FirstOrDefault(x => x.Contains(childName))
                                .Replace(childName, "").Trim();
                            child = new Person() { Birthday = childBirthday, Name = childName };
                        }
                        mainPerson.Children.Add(child);
                    }

                    else
                    {
                        var parent = new Person();
                        if (currentLine[0].Contains("/"))
                        {
                            var parentBirthday = currentLine[0].Trim();
                            var ParentName = nameBirthday.FirstOrDefault(x => x.Contains(parentBirthday))
                                .Replace(parentBirthday, "").Trim();
                            parent = new Person() { Birthday = parentBirthday, Name = ParentName };
                        }
                        else
                        {
                            var parentName = currentLine[0].Trim();
                            var ParentBirthday = nameBirthday.FirstOrDefault(x => x.Contains(parentName))
                                .Replace(parentName, "").Trim();
                            parent = new Person() { Birthday = ParentBirthday, Name = parentName };
                        }

                        mainPerson.Parents.Add(parent);
                    }
                }
            }

            Console.WriteLine($"{mainPerson}");
            Console.WriteLine("Parents:");

            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent}");
            }

            Console.WriteLine("Children:");

            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child}");
            }
        }
    }
}