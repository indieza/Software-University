namespace _03.Stack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var data = new CustomStack<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                if (input.Contains("Push"))
                {
                    var elements = input.Split(new string[] {", "," "}, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < elements.Length; i++)
                    {
                        data.Add(elements[i]);
                    }
                }
                else
                {
                    data.Remove();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var value in data)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
