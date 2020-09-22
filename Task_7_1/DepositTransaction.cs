using System;

namespace Task_7_1P
{
    /// <summary>
    /// Prototype for a deposit transaction
    /// </summary>
    class DepositTransaction : Transaction
    {
        // Instance variables
        private Account _account;

        public Account Account { get => _account; }

        /// <summary>
        /// Constructs a deposit transaction object
        /// </summary>
        /// <param name="account">Account to deposit into</param>
        /// <param name="amount">Amount to deposit</param>
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            _account = account;
        }

        /// <summary>
        /// Prints the details and status of a deposit
        /// </summary>
        public override void Print()
        {
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("|{0, -20}|{1, 20}|{2, 20}|{3, 20}|",
                "ACCOUNT", "DEPOSIT AMOUNT", "STATUS", "CURRENT BALANCE");
            Console.WriteLine(new String('-', 85));
            Console.Write("|{0, -20}|{1, 20}|", _account.Name, _amount.ToString("C"));
            if (!Executed)
            {
                Console.Write("{0, 20}|", "Pending");
            }
            else if (Reversed)
            {
                Console.Write("{0, 20}|", "Deposit reversed");
            }
            else if (Success)
            {
                Console.Write("{0, 20}|", "Deposit complete");
            }
            else if (!Success)
            {
                Console.Write("{0, 20}|", "Invalid deposit");
            }
            Console.WriteLine("{0, 20}|", _account.Balance.ToString("C"));
            Console.WriteLine(new String('-', 85));
        }

        /// <summary>
        /// Executes a deposit transaction
        /// </summary>
        public override void Execute()
        {
            base.Execute();

            _success = _account.Deposit(_amount);
            Console.WriteLine(Success);
            if (!_success)
            {
                throw new InvalidOperationException("Deposit amount invalid");
            }
        }

        /// <summary>
        /// Reverses a deposit if previously executed successfully
        /// </summary>
        public override void Rollback()
        {
            base.Rollback();

            bool complete = _account.Withdraw(_amount); // Withdraw returns boolean
            if (!complete) // Withdraw didn't occur
            {
                throw new InvalidOperationException("Insufficient funds to rollback");
            }
        }

        public override string GetAccountName()
        {
            return _account.Name;
        }
    }
}