namespace _06.CustomEnumAttribute
{
    using System;

    internal class CustomEnumAttribute
    {
        private static void Main()
        {
            var enumType = Console.ReadLine();

            Type type;

            if (enumType == "Rank")
            {
                type = typeof(Rank);
            }
            else
            {
                type = typeof(Suit);
            }

            var attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute.ToString());
            }
        }
    }
}