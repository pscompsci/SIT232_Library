using System;

namespace Task_7_1P
{
    /// <summary>
    /// Prototype for a Withdraw transaction
    /// </summary>
    class WithdrawTransaction : Transaction
    {
        // Instance variables
        private Account _account;

        /// <summary>
        /// Constructs a WithdrawTransaction
        /// </summary>
        /// <param name="account">Account to withdraw from</param>
        /// <param name="amount">Amount to withdraw</param>
        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            _account = account;
        }

        /// <summary>
        /// Prints the details and status of the withdrawal
        /// </summary>
        public override void Print()
        {
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("|{0, -20}|{1, 20}|{2, 20}|{3, 20}|",
                "ACCOUNT", "WITHDRAW AMOUNT", "STATUS", "CURRENT BALANCE");
            Console.WriteLine(new String('-', 85));
            Console.Write("|{0, -20}|{1, 20}|", _account.Name, _amount.ToString("C"));
            if (!Executed)
            {
                Console.Write("{0, 20}|", "Pending");
            }
            else if (Reversed)
            {
                Console.Write("{0, 20}|", "Withdraw reversed");
            }
            else if (Success)
            {
                Console.Write("{0, 20}|", "Withdraw complete");
            }
            else if (!Success)
            {
                Console.Write("{0, 20}|", "Insufficient funds");
            }
            Console.WriteLine("{0, 20}|", _account.Balance.ToString("C"));
            Console.WriteLine(new String('-', 85));
        }

        /// <summary>
        /// Executes the withdrawal
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown
        /// when the withdraw is already complete or insufficient funds</exception>
        public override void Execute()
        {
            base.Execute();

            _success = _account.Withdraw(_amount);
            if (!_success)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
        }

        /// <summary>
        /// Reverses the withdraw if previously executed successfully
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown
        /// if already rolled back or if there are insufficient
        /// funds to complete the rollback</exception>
        public override void Rollback()
        {
            base.Rollback();
            bool complete = _account.Deposit(_amount); // Deposit returns boolean
            if (!complete) // Deposit didn't occur
            {
                throw new InvalidOperationException("Invalid amount");
            }
        }

        public override string GetAccountName()
        {
            return _account.Name;
        }
    }
}