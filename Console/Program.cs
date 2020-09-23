using System;
using BusinessLogic;

namespace Console
{
    class Program
    {
        private static BankAccount s_bankAccount;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter name of bank account");
            string name = System.Console.ReadLine();

            System.Console.WriteLine("Enter balance for bank account");
            double balance = double.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());

            s_bankAccount = new BankAccount(name, balance);
            System.Console.WriteLine($"\nBank account for {s_bankAccount.CustomerName} created with balance: {s_bankAccount.Balance}\n");

            AccountOperations();
        }

        private static void AccountOperations()
        {
            System.Console.WriteLine("\nPress - for Debit | Press + for Credit\n");
            string input = System.Console.ReadLine();

            if (input == "+")
            {
                System.Console.WriteLine("Enter credit amount");
                double creditAmount = double.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
                s_bankAccount.Credit(creditAmount);
            }
            else if (input == "-")
            {
                System.Console.WriteLine("Enter debit amount");
                double debitAmount = double.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
                s_bankAccount.Debit(debitAmount);
            }

            System.Console.WriteLine($"Current balance is {s_bankAccount.Balance}");

            AccountOperations();
        }
    }
}
