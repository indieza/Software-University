namespace _06.StrategyPattern
{
    using System.Collections.Generic;

    public class PersonAgeComparator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}