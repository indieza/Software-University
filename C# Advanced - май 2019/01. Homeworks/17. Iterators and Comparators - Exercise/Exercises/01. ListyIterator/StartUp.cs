namespace _01.ListyIterator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var data = new ListyIterator<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input.Contains("Create"))
                {
                    data.Create(input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
                }
                else switch (input)
                    {
                        case "Move":
                            Console.WriteLine(data.Move());
                            break;

                        case "HasNext":
                            Console.WriteLine(data.HasNext());
                            break;

                        case "Print":
                            data.Print();
                            break;
                    }
            }
        }
    }
}