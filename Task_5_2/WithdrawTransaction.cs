using System;

namespace Task_4._2P
{
    /// <summary>
    /// Prototype for a Withdraw transaction
    /// </summary>
    class WithdrawTransaction
    {
        // Instance variables
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        // Properties
        public Boolean Executed { get => _executed; }
        public Boolean Success { get => _success; }
        public Boolean Reversed { get => _reversed; }

        /// <summary>
        /// Constructs a WithdrawTransaction
        /// </summary>
        /// <param name="account">Account to withdraw from</param>
        /// <param name="amount">Amount to withdraw</param>
        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account;
            if (amount > 0)
            {
                _amount = amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Withdrawal amount must be >  $0.00");
            }
            // _executed, _success, _reversed false by default
        }

        /// <summary>
        /// Prints the details and status of the withdrawal
        /// </summary>
        public void Print()
        {
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("|{0, -20}|{1, 20}|{2, 20}|{3, 20}|",
                "ACCOUNT", "WITHDRAW AMOUNT", "STATUS", "CURRENT BALANCE");
            Console.WriteLine(new String('-', 85));
            Console.Write("|{0, -20}|{1, 20}|", _account.Name, _amount.ToString("C"));
            if (!_executed)
            {
                Console.Write("{0, 20}|", "Pending");
            }
            else if (_reversed)
            {
                Console.Write("{0, 20}|", "Withdraw reversed");
            }
            else if (_success)
            {
                Console.Write("{0, 20}|", "Withdraw complete");
            }
            else if (!_success)
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
        public void Execute()
        {
            if (_executed && _success)
            {
                throw new InvalidOperationException("Withdraw previously executed");
            }
            _executed = true;

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
        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Transaction already reversed");
            }
            else if (!_success)
            {
                throw new InvalidOperationException(
                    "Withdraw not successfully executed. Nothing to rollback.");
            }
            _reversed = _account.Deposit(_amount); // Deposit returns boolean
            if (!_reversed) // Deposit didn't occur
            {
                throw new InvalidOperationException("Withdraw not reversed successfully");
            }
            _reversed = true;
        }
    }
}