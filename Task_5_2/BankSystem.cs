using System;
using System.Diagnostics;

namespace Task_4._2P
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Transfer,
        Print,
        Quit
    }

    /// <summary>
    /// BankSystem implements a banking system to operate on accounts
    /// </summary>
    class BankSystem
    {
        // Reads string input in the console
        /// <summary>
        /// Reads string input in the console
        /// </summary>
        /// <returns>
        /// The string input of the user
        /// </returns>
        /// <param name="prompt">The string prompt for the user</param>
        public static String ReadString(String prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }

        // Reads integer input in the console
        /// <summary>
        /// Reads integerinput in the console
        /// </summary>
        /// <returns>
        /// The input of the user as an integer
        /// </returns>
        /// <param name="prompt">The string prompt for the user</param>
        public static int ReadInteger(String prompt)
        {
            int number = 0;
            string numberInput = ReadString(prompt);
            while (!(int.TryParse(numberInput, out number)))
            {
                Console.WriteLine("Please enter a whole number");
                numberInput = ReadString(prompt);
            }
            return Convert.ToInt32(numberInput);
        }

        // Reads integer input in the console between two numbers
        /// <summary>
        /// Reads integer input in the console between two numbers
        /// </summary>
        /// <returns>
        /// The input of the user as an integer
        /// </returns>
        /// <param name="prompt">The string prompt for the user</param>
        /// <param name="minimum">The minimum number allowed</param>
        /// <param name="maximum">The maximum number allowed</param>
        public static int ReadInteger(String prompt, int minimum, int maximum)
        {
            int number = ReadInteger(prompt);
            while (number < minimum || number > maximum)
            {
                Console.WriteLine("Please enter a whole number from " +
                                  minimum + " to " + maximum);
                number = ReadInteger(prompt);
            }
            return number;
        }

        // Reads decimal input in the console
        /// <summary>
        /// Reads decimal input in the console
        /// </summary>
        /// <returns>
        /// The input of the user as a decimal
        /// </returns>
        /// <param name="prompt">The string prompt for the user</param>
        public static decimal ReadDecimal(String prompt)
        {
            decimal number = 0;
            string numberInput = ReadString(prompt);
            while (!(decimal.TryParse(numberInput, out number)) || number <= 0)
            {
                Console.WriteLine("Please enter a decimal number greater than $0.00");
                numberInput = ReadString(prompt);
            }
            return Convert.ToDecimal(numberInput);
        }

        /// <summary>
        /// Displays a menu of possible actions for the user to choose
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("\n********************");
            Console.WriteLine("*       Menu       *");
            Console.WriteLine("********************");
            Console.WriteLine("*  1. Withdraw     *");
            Console.WriteLine("*  2. Deposit      *");
            Console.WriteLine("*  3. Transfer     *");
            Console.WriteLine("*  4. Print        *");
            Console.WriteLine("*  5. Quit         *");
            Console.WriteLine("********************");
        }

        /// <summary>
        /// Returns a menu option chosen by the user
        /// </summary>
        /// <returns>
        /// MenuOption chosen by the user
        /// </returns>
        static MenuOption ReadUserOption()
        {
            DisplayMenu();
            int option = ReadInteger("Choose an option", 1,
                Enum.GetNames(typeof(MenuOption)).Length);
            return (MenuOption)(option - 1);
        }

        /// <summary>
        /// Attempts to deposit funds into an account
        /// </summary>
        /// <param name="account">The account to deposit into</param>
        static void DoDeposit(Account account)
        {
            decimal amount = ReadDecimal("Enter the amount");
            DepositTransaction transaction = new DepositTransaction(account, amount);
            try
            {
                transaction.Execute();
            }
            catch (InvalidOperationException)
            {
                transaction.Print();
                return;
            }
            transaction.Print();
        }

        /// <summary>
        /// Attempts to withdraw funds from an account
        /// </summary>
        /// <param name="account">The account to withdraw from</param>
        static void DoWithdraw(Account account)
        {
            decimal amount = ReadDecimal("Enter the amount");
            WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
            try
            {
                transaction.Execute();
            }
            catch (InvalidOperationException)
            {
                transaction.Print();
                return;
            }
            transaction.Print();
        }

        /// <summary>
        /// Attempts to transfer funds between accounts
        /// </summary>
        /// <param name="account">The account to withdraw from</param>
        static void DoTransfer(Account fromAccount, Account toAccount)  // this is temporary until we add multiple accounts in task 6.2
        {
            decimal amount = ReadDecimal("Enter the amount");
            try
            {
                TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
                transfer.Execute();
            }
            catch (Exception)
            {
                // Currently this is handled in the TransferTransaction. This will be changed
            }
        }

        /// <summary>
        /// Outputs the account name and balance
        /// </summary>
        /// <param name="account">The account to print</param>
        static void DoPrint(Account account)
        {
            account.Print();
        }

        static void Main(string[] args)
        {
            /*********************************************************
             *  TESTS
             ********************************************************/
            Account acc = new Account("Peter Stacey");
            Account acc1 = new Account("Jane Doe", 100);
            Account acc2 = new Account("John Doe", -500);

            Debug.Assert(acc.Balance == 0);
            Debug.Assert(acc1.Balance == 100);
            Debug.Assert(acc2.Balance == 0);

            // Test deposit success and rollback
            DepositTransaction dep = new DepositTransaction(acc, 500);

            dep.Print();
            dep.Execute();
            Debug.Assert(acc.Balance == 500);
            Debug.Assert(dep.Executed == true);
            Debug.Assert(dep.Success == true);
            dep.Print();

            dep.Rollback();
            Debug.Assert(acc.Balance == 0);
            Debug.Assert(dep.Reversed == true);
            dep.Print();

            Console.WriteLine("\n\n");

            // Test withdraw success and rollback
            WithdrawTransaction with = new WithdrawTransaction(acc1, 50);

            with.Print();
            with.Execute();
            Debug.Assert(acc1.Balance == 50);
            Debug.Assert(with.Executed == true);
            Debug.Assert(with.Success == true);
            with.Print();

            with.Rollback();
            Debug.Assert(acc1.Balance == 100);
            Debug.Assert(with.Reversed == true);
            with.Print();

            Console.WriteLine("\n\n");

            // Test transfer success and rollback
            TransferTransaction tran = new TransferTransaction(acc1, acc, 50);

            tran.Print();
            tran.Execute();
            Debug.Assert(acc.Balance == 50);
            Debug.Assert(acc1.Balance == 50);
            Debug.Assert(tran.Executed == true);
            Debug.Assert(tran.Success == true);

            tran.Rollback();
            Debug.Assert(acc.Balance == 0);
            Debug.Assert(acc1.Balance == 100);
            Debug.Assert(tran.Reversed == true);
            tran.Print();

            Console.WriteLine("\n\n");

            // Test withdraw failure when there is insufficient funds to complete the transaction
            // followed by repeating the withdraw after funds are deposited
            WithdrawTransaction with2 = new WithdrawTransaction(acc, 100);

            with2.Print();
            try
            {
                with2.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Debug.Assert(acc.Balance == 0);
            Debug.Assert(with2.Success == false);
            Debug.Assert(with2.Executed == true);
            with2.Print();

            DepositTransaction dep2 = new DepositTransaction(acc, 500);

            dep2.Execute();
            dep2.Print();

            try
            {
                with2.Execute();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Debug.Assert(acc.Balance == 400);
            Debug.Assert(with2.Success == true);
            Debug.Assert(with2.Executed == true);
            with2.Print();

            Console.WriteLine("\n\n");

            // Test fail to rollback before deposit or withdraw are
            // complete
            DepositTransaction dep3 = new DepositTransaction(acc, 500);
            WithdrawTransaction with3 = new WithdrawTransaction(acc, 500);
            TransferTransaction tran2 = new TransferTransaction(acc, acc1, 200);

            try
            {
                dep3.Rollback();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                with3.Rollback();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                tran2.Rollback();
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\n\n");

            // Try to rollback deposit from account with insufficient funds
            DepositTransaction dep4 = new DepositTransaction(acc2, 100);
            WithdrawTransaction with4 = new WithdrawTransaction(acc2, 100);

            dep4.Execute();
            with4.Execute();
            try
            {
                dep4.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("\n\n");

            /*********************************************************
             *  CLI
             ********************************************************/
            do
            {
                MenuOption chosen = ReadUserOption();
                switch (chosen)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(acc); break;
                    case MenuOption.Deposit:
                        DoDeposit(acc); break;
                    case MenuOption.Transfer:
                        DoTransfer(acc, acc1); break;
                    case MenuOption.Print:
                        DoPrint(acc); break;
                    case MenuOption.Quit:
                    default:
                        Console.WriteLine("Goodbye");
                        System.Environment.Exit(0); // terminates the program
                        break; // unreachable
                }
            } while (true);
        }
    }
}
