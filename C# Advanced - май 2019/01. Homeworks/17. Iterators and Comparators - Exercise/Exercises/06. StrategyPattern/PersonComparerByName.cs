namespace _06.StrategyPattern
{
    using System.Collections.Generic;

    public class PersonComparerByName:IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Name.Length.CompareTo(secondPerson.Name.Length)==0 
                ? firstPerson.Name.ToLower().CompareTo(secondPerson.Name.ToLower()) 
                : firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
        }
    }
}