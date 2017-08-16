using System;
using System.Reflection;

internal class OldestFamilyMember
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Family families = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] items = Console.ReadLine().Split();
            string name = items[0];
            int age = int.Parse(items[1]);

            families.AddMember(new Person(name, age));
        }

        Console.WriteLine(families.GetOldestMember());

        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }
    }
}