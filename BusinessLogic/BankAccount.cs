using System;

namespace BusinessLogic
{
    public class BankAccount
    {
        public const string NegativeValueNotAllowed = "Debit with negative value is not allowed";
        public const string BalanceToLow = "You don't have enough money";


        public string CustomerName { get; }
        public double Balance { get; private set; }

        public BankAccount(string customerName, double balance)
        {
            CustomerName = customerName;
            Balance = balance;
        }

        public void Debit(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, NegativeValueNotAllowed);
            }

            if (Balance < value)
            {
                throw new ArgumentOutOfRangeException(nameof(value),value, BalanceToLow);
            }

            Balance = Balance - value;
        }

        public void Credit(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, NegativeValueNotAllowed);
            }

            Balance = Balance + value;
        }

    }
}
