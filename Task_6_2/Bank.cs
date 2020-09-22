using System;
using System.Collections.Generic;

namespace Task_6._2P
{
    /// <summary>
    /// Prototype for a bank to hold accounts
    /// </summary>
    class Bank
    {
        // Instance variables
        private List<Account> _accounts;

        /// <summary>
        /// Creates an empty bank object with a list for accounts
        /// </summary>
        public Bank()
        {
            _accounts = new List<Account>();
        }

        /// <summary>
        /// Adds an account to the Bank accounts register
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        /// <summary>
        /// Returns the first Account corresponding to the name, or
        /// null if there is no account matching the criteria
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// Account matching the provided name, or null
        /// </returns>
        public Account GetAccount(string name)
        {
            foreach (Account account in _accounts)
            {
                if (account.Name == name)
                {
                    return account;
                }
            }
            return null;
        }

        /// <summary>
        /// Executes a deposit into an account
        /// </summary>
        /// <param name="transaction">DepositTransaction to execute</param>
        public void ExecuteTransaction(DepositTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("An error occurred in executing the transaction");
                Console.WriteLine("The error was: " + exception.Message);
            }
        }

        /// <summary>
        /// Executes a WithdrawTransaction on an account
        /// </summary>
        /// <param name="transaction">WithdrawTransaction to execute</param>
        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("An error occurred in executing the transaction");
                Console.WriteLine("The error was: " + exception.Message);
            }
        }

        /// <summary>
        /// Transfers funds between accounts held by the bank
        /// </summary>
        /// <param name="transaction">TransferTransaction to execute</param>
        public void ExecuteTransaction(TransferTransaction transaction)
        {
            try
            {
                transaction.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("An error occurred in executing the transaction");
                Console.WriteLine("The error was: " + exception.Message);
            }
        }
    }
}