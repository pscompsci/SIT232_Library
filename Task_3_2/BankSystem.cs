using System;

namespace Task_3._2P
{
    enum MenuOption
    {
        Withdraw,
        Deposit,
        Print,
        Quit
    }

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
            while (!(decimal.TryParse(numberInput, out number)))
            {
                Console.WriteLine("Please enter a decimal number");
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
            Console.WriteLine("*  3. Print        *");
            Console.WriteLine("*  4. Quit         *");
            Console.WriteLine("********************");
        }

        /// <summary>
        /// Displays the outcome of a deposit or withdraw action
        /// </summary>
        /// <param name="action">The MenuOption currently in use</param>
        /// <param name="result">Boolean result of the deposit or withdraw</param>
        private static void DisplayResult(MenuOption action, Boolean result)
        {
            String output = action + " "
                + (result == true ? "succeeded" : "failed. Invalid amount.");
            Console.WriteLine(output);
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
            bool result = account.Deposit(amount);
            DisplayResult(MenuOption.Deposit, result);
        }

        /// <summary>
        /// Attempts to withdraw funds from an account
        /// </summary>
        /// <param name="account">The account to withdraw from</param>
        static void DoWithdraw(Account account)
        {
            decimal amount = ReadDecimal("Enter the amount");
            Boolean result = account.Withdraw(amount);
            DisplayResult(MenuOption.Withdraw, result);
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

            Console.WriteLine(typeof(MenuOption));

            Account acc0 = new Account("Peter Stacey");
            Account acc = new Account("Jane Doe", 100);
            Account acc1 = new Account("Shonky Trev", -500);

            acc0.Print(); // confirm balance of $0.00 when no balance to constructor
            acc.Print();  // confirm balance not set to negative
            acc1.Print(); // confirm no overdrawn account creation

            Console.WriteLine("Name accessed via a property: {0}", acc.Name);

            do
            {
                MenuOption chosen = ReadUserOption();
                switch (chosen)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(acc); break;
                    case MenuOption.Deposit:
                        DoDeposit(acc); break;
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
