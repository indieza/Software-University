using System;

namespace _04.Telephony
{
    internal class Telephony
    {
        private static void Main()
        {
            string[] phones = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();

            foreach (var phone in phones)
            {
                smartphone.AddPhone(phone);
            }

            foreach (var website in websites)
            {
                smartphone.AddWebsite(website);
            }

            Console.WriteLine(smartphone.Call());
            Console.WriteLine(smartphone.Browse());
        }
    }
}