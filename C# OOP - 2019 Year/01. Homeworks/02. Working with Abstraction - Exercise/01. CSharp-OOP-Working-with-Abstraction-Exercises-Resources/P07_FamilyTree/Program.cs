using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(firstPerson))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Birthday = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Name = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }
                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person) + 1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];
                    familyTree.CopyTo(index, copy, 0, count);

                    Person copyPerson = copy.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);

                    if (copyPerson != null)
                    {
                        familyTree.Remove(copyPerson);
                        person.Parents.AddRange(copyPerson.Parents);
                        person.Parents = person.Parents.Distinct().ToList();

                        person.Children.AddRange(copyPerson.Children);
                        person.Children = person.Children.Distinct().ToList();
                    }
                }
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Children:");
            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (!familyTree.Any(p => p.Birthday == child))
                {
                    childPerson.Birthday = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == child);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == child))
                {
                    childPerson.Name = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == child);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
