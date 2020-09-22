using System;
using System.Diagnostics;

namespace Task_6._2P
{
    enum MenuOption
    {
        CreateAccount,
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
            while (!(decimal.TryParse(numberInput, out number)) || number < 0)
            {
                Console.WriteLine("Please enter a decimal number, $0.00 or greater");
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
            Console.WriteLine("*  1. New Account  *");
            Console.WriteLine("*  2. Withdraw     *");
            Console.WriteLine("*  3. Deposit      *");
            Console.WriteLine("*  4. Transfer     *");
            Console.WriteLine("*  5. Print        *");
            Console.WriteLine("*  6. Quit         *");
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
        /// Attempts to deposit funds into an account at a bank
        /// </summary>
        /// <param name="bank">The bank holding the account to deposit into</param>
        static void DoDeposit(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                decimal amount = ReadDecimal("Enter the amount");
                DepositTransaction transaction = new DepositTransaction(account, amount);
                try
                {
                    bank.ExecuteTransaction(transaction);
                }
                catch (InvalidOperationException)
                {
                    transaction.Print();
                    return;
                }
                transaction.Print();
            }
        }

        /// <summary>
        /// Attempts to withdraw funds from an account at a bank
        /// </summary>
        /// <param name="bank">The bank holding account to withdraw from</param>
        static void DoWithdraw(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                decimal amount = ReadDecimal("Enter the amount");
                WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
                try
                {
                    bank.ExecuteTransaction(transaction);
                }
                catch (InvalidOperationException)
                {
                    transaction.Print();
                    return;
                }
                transaction.Print();
            }
        }

        /// <summary>
        /// Attempts to transfer funds between accounts
        /// </summary>
        /// <param name="bank">The bank holding the account
        /// to transfer between</param>
        static void DoTransfer(Bank bank)
        {
            Console.WriteLine("Transfer from:");
            Account from = FindAccount(bank);
            Console.WriteLine("Transfer to:");
            Account to = FindAccount(bank);
            if (from != null && to != null)
            {
                decimal amount = ReadDecimal("Enter the amount");
                try
                {
                    TransferTransaction transaction = TransferTransaction.Builder
                        .FromAccount(from)
                        .ToAccount(to)
                        .Amount(amount)
                        .Build();
                    bank.ExecuteTransaction(transaction);
                    transaction.Print();
                }
                catch (Exception)
                {
                    // Currently this is handled in the TransferTransaction. This will be changed
                }
            }
        }

        /// <summary>
        /// Outputs the account name and balance
        /// </summary>
        /// <param name="account">The account to print</param>
        static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                account.Print();
            }
        }

        /// <summary>
        /// Creates a new account and adds it to the Bank
        /// </summary>
        /// <param name="bank">The bank to create the account in</param>
        static void CreateAccount(Bank bank)
        {
            string name = ReadString("Enter account name");
            decimal balance = ReadDecimal("Enter the opening balance");
            bank.AddAccount(new Account(name, balance));
        }

        private static Account FindAccount(Bank bank)
        {
            string name = ReadString("Enter the account name");
            Account account = bank.GetAccount(name);
            if (account == null)
            {
                Console.WriteLine("That account name does not exist at this bank");
            }
            return account;
        }

        static void Main(string[] args)
        {
            Bank bank = new Bank();

            do
            {
                MenuOption chosen = ReadUserOption();
                switch (chosen)
                {
                    case MenuOption.CreateAccount:
                        CreateAccount(bank); break;

                    case MenuOption.Withdraw:
                        DoWithdraw(bank); break;

                    case MenuOption.Deposit:
                        DoDeposit(bank); break;

                    case MenuOption.Transfer:
                        DoTransfer(bank); break;

                    case MenuOption.Print:
                        DoPrint(bank); break;

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
