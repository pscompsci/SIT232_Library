using System;

namespace Task_2._2P
{
    class TestAccount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n*************");
            Console.WriteLine("TESTING START");
            Console.WriteLine("*************");

            Console.WriteLine("\n----------------------");
            Console.WriteLine("GOOD ACCOUNT BEHAVIOUR");
            Console.WriteLine("----------------------");

            Account okAccount = new Account("Mrs Good", 0);

            okAccount.Print(); // Expect balance to be $0.00
            okAccount.Deposit(500);
            okAccount.Withdraw(100);
            okAccount.Print(); // Expect balance to be $400.00
            Console.WriteLine("Account name: " + okAccount.Name);

            Console.WriteLine("\n---------------------");
            Console.WriteLine("BAD ACCOUNT BEHAVIOUR");
            Console.WriteLine("---------------------");

            Account badAccount = new Account("Mr Bad", -100); // Allows a negative balance

            badAccount.Print(); // Expect balance to be -$100.00
            badAccount.Deposit(100);
            badAccount.Print(); // Expect balance to be $0.00
            badAccount.Withdraw(1000000000); // Expect $1 billion overdrawn
            badAccount.Print();
            // badAccount.Name = "I'm really ok"; // Confirm read-only

            Console.WriteLine("\n-------------------");
            Console.WriteLine("ATTEMPTED BEHAVIOUR");
            Console.WriteLine("-------------------");

            Account terribleAccount = new Account("okAccount.Withdraw(1000);", 0); // Attempting to affect ok account
            terribleAccount.Print();
            okAccount.Print(); // Expect $400.00

            Console.WriteLine("\n***********");
            Console.WriteLine("TESTING END");
            Console.WriteLine("***********\n");

            Console.ReadLine();
        }
    }
}
