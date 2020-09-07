using System;

namespace BusinessLogic
{
    public class BankAccount
    {
        private readonly string _customerName;
        public double Balance { get; private set; }

        public BankAccount(string customerName, double balance)
        {
            _customerName = customerName;
            Balance = balance;
        }

        public void Debit(double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("IMPOSSIBLE");
            }

            Balance = Balance - value;
        }

        public void Credit(double value)
        {

        }







    }
}
