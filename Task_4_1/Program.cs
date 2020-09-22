using System;
using System.Text;

namespace Task_4._1P
{

    /// <summary>
    /// Helper class for the exception implementations. It models
    /// a simple account class for an account holder and their balance.
    /// </summary>
    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        /// <summary>
        /// Constructor for an account
        /// </summary>
        /// <param name="firstName">Account holder's first name</param>
        /// <param name="lastName">Account holder's last name</param>
        /// <param name="balance">Balance of the account as an int</param>
        public Account(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        /// <summary>
        /// Attempts to withdraw funds from the account if sufficient
        /// funds are available
        /// </summary>
        /// <param name="amount">The amount to attempt to withdraw</param>
        /// <exception cref="System.InvalidOperationException">Thrown
        /// when the amount to withdraw is more than the available
        /// funds</exception>
        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            Balance = Balance - amount;
        }
    }

    /// <summary>
    /// Empty class definition to assist with the ArgumentException 
    /// example
    /// </summary>
    public class MyClass { }

    /// <summary>
    /// Helper class for the ArgumentOutOfRangeException, which we 
    /// encountered in Task 2.3C
    /// </summary>
    class MyTime
    {
        // Instance variables
        private int _hour;
        private int _minute;
        private int _second;

        /// Reference for this approach, from:
        /// https://stackoverflow.com/questions/56197825
        public int Hour
        {
            get => _hour;
            set => _hour = (value >= 0) && (value <= 23)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid hour. Must be 0-23");
        }

        public int Minute
        {
            get => _minute;
            set => _minute = (value >= 0) && (value <= 59)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid minute. Must be 0-59");
        }

        public int Second
        {
            get => _second;
            set => _second = (value >= 0) && (value <= 59)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid second. Must be 0-59");
        }

        public MyTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }

    class Program
    {
        // Theoretically sets a limit on the number of recursive
        // calls in the execute method, but this is bypassed in
        // the implementation
        const int MAX_RECURSIVE_CALLS = 1000;

        /// <summary>
        /// Helper method for the StackOverflowException
        /// </summary>
        /// <param name="counter"></param>
        static void Execute(int counter)
        {
            counter++;

            if (counter <= MAX_RECURSIVE_CALLS)
                counter--;

            Execute(counter);
        }

        public static void Main(string[] args)
        {
            // NullReference Example
            int[] values = null;

            try
            {
                // NullReferenceException occurs here because the
                // loop attempts to set a value within the array
                // but the size of the array has not been set
                // so no position can be addressed, as it is null
                for (int i = 0; i < 10; i++)
                    values[i] = i * 2;

                foreach (var value in values)
                    Console.WriteLine(value);
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // IndexOutOfRange Example
            try
            {
                values = new int[10];

                // IndexOutOfRangeException occurs here because the loop
                // attempts to set a value for an index equal to the
                // length of the array, which is one more than the last
                // available index value (ie. values[10] is beyond the
                // end of the array)
                for (int i = 0; i <= values.Length; i++)
                {
                    values[i] = i * 2;
                }

                foreach (var value in values)
                    Console.WriteLine(value);

            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // StackOverflow Example
            try
            {
                // Will cause recursive filling of the stack with
                // increment and decrement steps
                // Execute(0);
            }
            catch (StackOverflowException exception)
            {
                // This catch block will never be executed as a
                // stack overflow always terminates the program
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // OutOfMemory Example
            try
            {
                // OutOfMemory occurs because the capacity and length
                // are set smaller than the amount of memory required
                // to create the initial string and then insert
                // the second string into the first at index 0
                StringBuilder sb = new StringBuilder(15, 15);
                sb.Append("Substring #1 ");
                sb.Insert(0, "Substring #2 ", 1);
            }
            catch (OutOfMemoryException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // InvalidCast Example
            try
            {
                bool flag = true;
                char ch = Convert.ToChar(flag); // bool cannot cast to char
            }
            catch (InvalidCastException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // DivideByZeroException Example
            try
            {
                int x = 1000;
                int y = 0;

                // This is a simple and explicitly coded 0, however this
                // is more relevant where a method involves some division
                // involving arguments and/or where user or sensor input 
                // is involved
                Console.WriteLine(x / y);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // ArgumentException Example
            try
            {
                MyClass my = new MyClass();
                string s = "test text";
                int i = s.CompareTo(my); // comparing object to string
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // ArgumentOutOfRangeException Example
            try
            {
                MyTime t = new MyTime(24, 0, 0); // 24 is larger than the allowed range
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // SystemException Example
            try
            {
                // This is the base class for other exceptions and
                // is normally reserved for runtime errors in the
                // CLR and a more specific exception type should be derived
                // or thrown
                int[] array = new int[5];
                array[10] = 25; // This is also an IndexOutOfRangeException
            }
            catch (SystemException exception)  // This is normally bad
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }

            // Original code supplied in the task for an 
            // InvalidOperationException
            try
            {
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine("The following error detected: "
                    + exception.GetType().ToString()
                    + " with message \"" + exception.Message + "\"");
            }
        }
    }
}
