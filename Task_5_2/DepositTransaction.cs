using System;

namespace Task_4._2P
{
    /// <summary>
    /// Prototype for a deposit transaction
    /// </summary>
    class DepositTransaction
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
        /// Constructs a deposit transaction object
        /// </summary>
        /// <param name="account">Account to deposit into</param>
        /// <param name="amount">Amount to deposit</param>
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            if (amount > 0)
            {
                _amount = amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                    "Deposit amount invalid: {0}", amount.ToString("C"));
            }
            // _executed, _success, _reversed false by default
        }

        /// <summary>
        /// Prints the details and status of a deposit
        /// </summary>
        public void Print()
        {
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("|{0, -20}|{1, 20}|{2, 20}|{3, 20}|",
                "ACCOUNT", "DEPOSIT AMOUNT", "STATUS", "CURRENT BALANCE");
            Console.WriteLine(new String('-', 85));
            Console.Write("|{0, -20}|{1, 20}|", _account.Name, _amount.ToString("C"));
            if (!_executed)
            {
                Console.Write("{0, 20}|", "Pending");
            }
            else if (_reversed)
            {
                Console.Write("{0, 20}|", "Deposit reversed");
            }
            else if (_success)
            {
                Console.Write("{0, 20}|", "Deposit complete");
            }
            else if (!_success)
            {
                Console.Write("{0, 20}|", "Invalid deposit");
            }
            Console.WriteLine("{0, 20}|", _account.Balance.ToString("C"));
            Console.WriteLine(new String('-', 85));
        }

        /// <summary>
        /// Executes a deposit transaction
        /// </summary>
        public void Execute()
        {
            if (_executed && _success)
            {
                throw new InvalidOperationException("Deposit previously executed");
            }
            _executed = true;

            _success = _account.Deposit(_amount);
            if (!_success)
            {
                throw new InvalidOperationException("Deposit amount invalid");
            }
        }

        /// <summary>
        /// Reverses a deposit if previously executed successfully
        /// </summary>
        public void Rollback()
        {
            if (_reversed)
            {
                throw new InvalidOperationException("Transaction already reversed");
            }
            else if (!_success)
            {
                throw new InvalidOperationException(
                    "Deposit not successfully executed. Nothing to rollback.");
            }
            _reversed = _account.Withdraw(_amount); // Withdraw returns boolean
            if (!_reversed) // Withdraw didn't occur
            {
                throw new InvalidOperationException("Insufficient funds to rollback");
            }
            _reversed = true;
        }
    }
}