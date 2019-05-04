using System;

namespace BankAccount
{
    public class BankAccount
    {
        private string name;
        private decimal balance;

        public BankAccount(string name, decimal amount)
        {
            this.Name = name;
            this.Balance = amount;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentException($"Invalid {nameof(this.name)} length");
                }

                this.name = value;
            }
        }

        public decimal Balance
        {
            get => this.balance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Balance)} must be positive!");
                }

                this.balance = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be positive");
            }

            this.Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            if (this.Balance <= amount || amount < 0)
            {
                throw new InvalidOperationException($"{nameof(amount)} must be more than 0 and less than your balance");
            }

            this.Balance -= amount;
            return amount;
        }
    }
}
