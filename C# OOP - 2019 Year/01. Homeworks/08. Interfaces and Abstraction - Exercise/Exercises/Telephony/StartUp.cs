using System;

namespace Telephony
{
    public class StartUp
    {
        private static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split();
            var webAddress = Console.ReadLine().Split();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    var smartPhone = new Smartphone { PhoneNumber = phoneNumber };
                    Console.WriteLine(smartPhone.Call());
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }
            }

            foreach (var address in webAddress)
            {
                try
                {
                    var smartPhone = new Smartphone { WebAddress = address };
                    Console.WriteLine(smartPhone.Browse());
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }
            }
        }
    }
}