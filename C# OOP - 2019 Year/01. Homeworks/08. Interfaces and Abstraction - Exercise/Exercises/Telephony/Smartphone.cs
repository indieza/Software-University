namespace Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICall, IBrowse
    {
        private string phoneNumber;
        private string webAddress;

        public string PhoneNumber
        {
            get => this.phoneNumber;

            set
            {
                if (CheckPhoneNumber(value))
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.phoneNumber = value;
            }
        }

        public string WebAddress
        {
            get => this.webAddress;

            set
            {
                if (CheckWebAddress(value))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.webAddress = value;
            }
        }

        private bool CheckPhoneNumber(string value)
        {
            return value.FirstOrDefault(c => !char.IsDigit(c)) != 0;
        }

        private bool CheckWebAddress(string value)
        {
            return value.FirstOrDefault(c => char.IsDigit(c)) != 0;
        }

        public string Browse()
        {
            return $"Browsing: {this.WebAddress}!";
        }

        public string Call()
        {
            return $"Calling... {this.PhoneNumber}";
        }
    }
}