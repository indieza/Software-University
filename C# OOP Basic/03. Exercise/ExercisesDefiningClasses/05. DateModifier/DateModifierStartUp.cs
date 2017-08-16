using System;

internal class DateModifierStartUp
{
    private static void Main()
    {
        string startDay = Console.ReadLine();
        string endDay = Console.ReadLine();

        var modifier = new global::DateModifier(startDay, endDay);

        Console.WriteLine(modifier.Result);
    }
}