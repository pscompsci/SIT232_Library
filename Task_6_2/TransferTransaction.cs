using System;

namespace Task_6._2P
{
    /// <summary>
    /// Prototype for a transfer transaction
    /// </summary>
    public class TransferTransaction
    {
        public static TransferTransactionBuilder Builder => new TransferTransactionBuilder();

        // Instance variables
        public Account FromAccount { get; private set; }
        public Account ToAccount { get; private set; }
        public decimal Amount { get; private set; }
        public DepositTransaction Deposit { get; }
        private WithdrawTransaction Withdraw { get; }
        public bool Executed { get; private set; }
        public bool Reversed { get; private set; }
        public bool Success { get => Deposit.Success && Withdraw.Success; }


        /// <summary>
        /// Constructor for a transfer transaction
        /// </summary>
        /// <param name="fromAccount">The account to transfer from</param>
        /// <param name="toAccount">The account to transfer to</param>
        /// <param name="amount">The amount to transfer</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when the amount is negative</exception>
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;

            Withdraw = new WithdrawTransaction(FromAccount, Amount);
            Deposit = new DepositTransaction(ToAccount, Amount);
        }

        /// <summary>
        /// Prints the details of the transfer
        /// </summary>
        public void Print()
        {
            Console.WriteLine(new String('-', 85));
            Console.WriteLine("|{0, -20}|{1, 20}|{2, 20}|{3, 20}|",
                "FROM ACCOUNT", "To ACCOUNT", "TRANSFER AMOUNT", "STATUS");
            Console.WriteLine(new String('-', 85));
            Console.Write("|{0, -20}|{1, 20}|{2, 20}|", FromAccount.Name,
                ToAccount.Name, Amount.ToString("C"));
            if (!Executed)
            {
                Console.WriteLine("{0, 20}|", "Pending");
            }
            else if (Reversed)
            {
                Console.WriteLine("{0, 20}|", "Transfer reversed");
            }
            else if (Success)
            {
                Console.WriteLine("{0, 20}|", "Transfer complete");
            }
            else if (!Success)
            {
                Console.WriteLine("{0, 20}|", "Transfer failed");
            }
            Console.WriteLine(new String('-', 85));
        }

        /// <summary>
        /// Executes the transfer
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown
        /// when previously executed or deposit or withdraw fail</exception>
        public void Execute()
        {
            if (Executed)
            {
                throw new InvalidOperationException("Transfer previously executed");
            }
            Executed = true;

            try
            {
                Withdraw.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("Transfer failed with reason: " + exception.Message);
                Withdraw.Print();
            }

            if (Withdraw.Success)
            {
                try
                {
                    Deposit.Execute();
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine(
                        "Transfer failed with reason: " + exception.Message);
                    Deposit.Print();
                    try
                    {
                        Withdraw.Rollback();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(
                            "Withdraw could not be reversed with reason: "
                            + e.Message);
                        Withdraw.Print();
                    }
                }
            }
        }

        /// <summary>
        /// Rolls the transfer back
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown
        /// when the rollback has already been executed or it fails</exception>
        public void Rollback()
        {
            if (!Executed)
            {
                throw new InvalidOperationException(
                    "Transfer not executed. Nothing to rollback.");
            }

            if (Reversed)
            {
                throw new InvalidOperationException("Transfer already rolled back");
            }

            if (this.Success)
            {
                try
                {
                    Deposit.Rollback();
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine("Failed to rollback deposit: "
                        + exception.Message);
                    return;
                }

                try
                {
                    Withdraw.Rollback();
                }
                catch (InvalidOperationException exception)
                {
                    Console.WriteLine("Failed to rollback withdraw: "
                        + exception.Message);
                    return;
                }
            }
            Reversed = true;
        }

        public class TransferTransactionBuilder
        {
            private Account _fromAccount;
            private Account _toAccount;
            private decimal _amount;

            public TransferTransactionBuilder FromAccount(Account from)
            {
                if (from == null) throw new ArgumentNullException(nameof(from));
                _fromAccount = from;
                return this;
            }

            public TransferTransactionBuilder ToAccount(Account to)
            {
                if (to == null) throw new ArgumentNullException(nameof(to));
                _toAccount = to;
                return this;
            }

            public TransferTransactionBuilder Amount(decimal amount)
            {
                if (amount < 0) throw new ArgumentOutOfRangeException(
                    "Amount less than 0");
                _amount = amount;
                return this;
            }

            public TransferTransaction Build()
            {
                return new TransferTransaction(_fromAccount, _toAccount, _amount);
            }
        }
    }
}