using System;
using System.Collections.Generic;

internal class BankAccountSystem
{
    private static void Main()
    {
        string line = Console.ReadLine();

        Dictionary<int, BankAccount> account = new Dictionary<int, BankAccount>();

        while (line != "End")
        {
            string[] items = line.Split();
            string command = items[0];

            switch (command)
            {
                case "Create":
                    Create(items, account);
                    break;

                case "Deposit":
                    Deposit(items, account);
                    break;

                case "Withdraw":
                    Withdraw(items, account);
                    break;

                case "Print":
                    Print(items, account);
                    break;
            }

            line = Console.ReadLine();
        }
    }

    private static void Print(string[] items, Dictionary<int, BankAccount> account)
    {
        int id = int.Parse(items[1]);
        if (account.ContainsKey(id))
        {
            Console.WriteLine(account[id].ToString());
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] items, Dictionary<int, BankAccount> account)
    {
        int id = int.Parse(items[1]);
        double amount = double.Parse(items[2]);

        if (account.ContainsKey(id))
        {
            if (account[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                account[id].Withdraw(amount);
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] items, Dictionary<int, BankAccount> account)
    {
        int id = int.Parse(items[1]);
        double amount = double.Parse(items[2]);

        if (account.ContainsKey(id))
        {
                account[id].Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] items, Dictionary<int, BankAccount> account)
    {
        int id = int.Parse(items[1]);
        if (account.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.ID = id;
            account.Add(id, bankAccount);
        }
    }
}