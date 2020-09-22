using System;

namespace Task_2._2P
{
    /// <summary>
    /// A bank account class to hold the account name and balance details
    /// </summary>
    class Account
    {
        // Instance variables
        private String _name;
        private decimal _balance;

        // Read-only properties
        public String Name { get { return _name; } }


        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="name">The name string for the account</param>
        /// <param name="balance">The decimal balance of the account</param>
        public Account(String name, decimal balance)
        {
            _name = name;
            _balance = balance;  // !Allows negative initial balance
        }

        /// <summary>
        /// Deposits money into the account
        /// </summary>
        /// <param name="amount">The decimal amount to add to the balance</param>
        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        /// <summary>
        /// Withdraws money from the account (with no overdraw protection currently)
        /// </summary>
        /// <param name="amount">The amount to subtract from the balance</param>
        public void Withdraw(decimal amount)
        {
            _balance -= amount; // !Allows unlimited overdraw
        }

        /// <summary>
        /// Outputs the account name and current balance as a string
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Account Name: {0}, Balance: {1}",
                _name, _balance.ToString("C"));
        }
    }
}
