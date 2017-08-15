namespace PredicateForNames
{
    using System;

    internal class PredicateForNames
    {
        private static void Main()
        {
            int maxLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isNameShorterOrEqual = name => name.Length <= maxLength;

            foreach (string name in names)
            {
                if (isNameShorterOrEqual.Invoke(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}