namespace _06.StrategyPattern
{
    using System.Collections.Generic;

    public class PersonComparerByAge:IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
