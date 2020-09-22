using System;
using System.Collections.Generic;

namespace Task_7_1P
{
    /// <summary>
    /// Prototype for a bank to hold accounts
    /// </summary>
    class Bank
    {
        private List<Account> _accounts;
        public List<Transaction> Transactions { get; private set; }

        /// <summary>
        /// Creates an empty bank object with a list for accounts
        /// </summary>
        public Bank()
        {
            _accounts = new List<Account>();
            Transactions = new List<Transaction>();
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
        /// Executes a transaction
        /// </summary>
        /// <param name="transaction">Transaction to execute</param>
        public void Execute(Transaction transaction)
        {
            Transactions.Add(transaction);
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
        /// Rolls a transaction back
        /// </summary>
        /// <param name="transaction">Transaction to execute</param>
        public void Rollback(Transaction transaction)
        {
            try
            {
                transaction.Rollback();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("An error occurred in rolling the transaction back");
                Console.WriteLine("The error was: " + exception.Message);
            }
        }

        /// <summary>
        /// Helper function for PrintTransactionHistory that converts the
        /// type of the transaction to a string
        /// </summary>
        /// <param name="transaction">The transaction to return the
        /// type of</param>
        /// <returns>
        /// The type as a string representation
        /// </returns>
        public string TransactionType(Transaction transaction)
        {
            switch (transaction.GetType().ToString())
            {
                case "Task_7_1P.DepositTransaction":
                    return "Deposit";
                case "Task_7_1P.WithdrawTransaction":
                    return "Withdraw";
                case "Task_7_1P.TransferTransaction":
                    return "Transfer";
            }
            return "Unknown";
        }

        /// <summary>
        /// Helper function for PrintTransactionHistory that converts the
        /// current status to a string representation
        /// </summary>
        /// <param name="transaction">The transaction to return the
        /// type of</param>
        /// <returns>
        /// The status as a string representation
        /// </returns>
        public string TransactionStatus(Transaction transaction)
        {
            if (!transaction.Executed)
            {
                return "Pending";
            }
            else if (transaction.Reversed)
            {
                return "Reversed";
            }
            else if (!transaction.Success)
            {
                return "Incomplete";
            }
            else
            {
                return "Complete";
            }
        }

        /// <summary>
        /// Writes the list of transactions to the Console in a table format
        /// </summary>
        public void PrintTransactionHistory()
        {
            string transactionType = "";
            string transactionStatus = "";
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("| {0,2} |{1,-25} | {2,-15}|{3,15} | {4,15} |", "#",
                    "DateTime", "Type", "Amount", "Status");
            Console.WriteLine(new String('=', 85));
            for (int i = 0; i < Transactions.Count; i++)
            {
                transactionType = TransactionType(Transactions[i]);
                transactionStatus = TransactionStatus(Transactions[i]);
                Console.WriteLine("| {0,2} |{1,-25} | {2,-15}|{3,15} | {4,15} |", i + 1,
                    Transactions[i].DateStamp, transactionType,
                    Transactions[i].Amount.ToString("C"), transactionStatus);
            }
            Console.WriteLine(new String('=', 85));
        }
    }
}