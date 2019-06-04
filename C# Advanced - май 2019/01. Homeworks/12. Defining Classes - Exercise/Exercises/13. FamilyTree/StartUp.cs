namespace _13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _13.FamilyTree.Classes;

    public class StartUp
    {
        public static void Main()
        {
            List<string> nameBirthday = new List<string>();
            List<string> parentChild = new List<string>();
            string peopleBirthday = string.Empty;
            string peopleName = string.Empty;
            Person person = new Person();

            while (true)
            {
                string input = Console.ReadLine();

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

            if (nameBirthday[0].Contains('/'))
            {
                peopleBirthday = nameBirthday[0];
                peopleName = nameBirthday
                   .FirstOrDefault(x => x.Contains(peopleBirthday) && x.Length > peopleBirthday.Length)
                   .Replace(peopleBirthday, "").Trim();
            }
            else
            {
                peopleName = nameBirthday[0];
                peopleBirthday = nameBirthday.FirstOrDefault(x => x.Contains(peopleName) && x.Contains("/"))
                    .Replace(peopleName, "").Trim();
            }

            person = new Person()
            {
                Name = peopleName,
                Birthday = peopleBirthday
            };

            foreach (var line in parentChild)
            {
                if (line.Contains(peopleName) || line.Contains(peopleBirthday))
                {
                    string[] currentLine = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string currentBirthday = string.Empty;
                    string currentName = string.Empty;

                    if (currentLine[0] == peopleBirthday || currentLine[0] == peopleName)
                    {
                        Child child = new Child();

                        if (currentLine[1].Contains("/"))
                        {
                            string childBirthday = currentLine[1];
                            string childName = nameBirthday.FirstOrDefault(x => x.Contains(childBirthday))
                                .Replace(childBirthday, "").Trim();
                            child = new Child() { ChildBirthday = childBirthday, ChildName = childName };
                        }
                        else
                        {
                            string childName = currentLine[1];
                            string childBirthday = nameBirthday.FirstOrDefault(x => x.Contains(childName))
                                .Replace(childName, "").Trim();
                            child = new Child() { ChildBirthday = childBirthday, ChildName = childName };
                        }
                        person.Children.Add(child);
                    }
                    else
                    {
                        Parent parent = new Parent();

                        if (currentLine[0].Contains("/"))
                        {
                            string parentBirthday = currentLine[0].Trim();
                            string ParentName = nameBirthday.FirstOrDefault(x => x.Contains(parentBirthday))
                                .Replace(parentBirthday, "").Trim();
                            parent = new Parent() { ParentBirthDay = parentBirthday, ParentName = ParentName };
                        }
                        else
                        {
                            string parentName = currentLine[0].Trim();
                            string ParentBirthday = nameBirthday.FirstOrDefault(x => x.Contains(parentName))
                                .Replace(parentName, "").Trim();
                            parent = new Parent() { ParentBirthDay = ParentBirthday, ParentName = parentName };
                        }

                        person.Parent.Add(parent);
                    }
                }
            }

            Console.WriteLine($"{person.Name} {person.Birthday}");
            Console.WriteLine("Parents:");

            foreach (var parent in person.Parent)
            {
                Console.WriteLine($"{parent.ParentName} {parent.ParentBirthDay}");
            }

            Console.WriteLine("Children:");

            foreach (var child in person.Children)
            {
                Console.WriteLine($"{child.ChildName} {child.ChildBirthday}");
            }
        }
    }
}