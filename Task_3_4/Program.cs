using System;
using System.Collections.Generic;

namespace Task_3._4D
{
    class Program
    {

        static void PrintAccountArray(Account[] accounts)
        {
            foreach (Account account in accounts)
                account.Print();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("\n*************************************************");
            Console.WriteLine("** TESTING START");
            Console.WriteLine("*************************************************\n");

            Random random = new Random();
            int numberOfAccounts = random.Next(15, 50);

            // Testing REASONABLE Arguments

            Account[] accountsArray = new Account[numberOfAccounts];
            for (int i = 0; i < accountsArray.Length; i++)
            {
                accountsArray[i] = new Account("Jane Doe", Convert.ToDecimal(random.Next(10, 5000)));
            }

            Console.WriteLine("\n*************************************************");
            Console.WriteLine("** Array Order before beginning to sort:");
            Console.WriteLine("*************************************************\n");

            PrintAccountArray(accountsArray);
            AccountSorter.Sort(accountsArray, 5);

            Console.WriteLine("\n*************************************************");
            Console.WriteLine("** Array Order After sorting:");
            Console.WriteLine("*************************************************\n");

            PrintAccountArray(accountsArray);

            List<Account> accountsList = new List<Account>();
            for (int i = 0; i < numberOfAccounts; i++)
            {
                accountsList.Add(new Account("Jane Doe", Convert.ToDecimal(random.Next(10, 5000))));
            }

            Console.WriteLine("\n*************************************************");
            Console.WriteLine("** List Order before beginning to sort:");
            Console.WriteLine("*************************************************\n");

            PrintAccountArray(accountsList.ToArray());
            AccountSorter.Sort(accountsList, 5);

            Console.WriteLine("\n*************************************************");
            Console.WriteLine("** List Order After sorting:");
            Console.WriteLine("*************************************************\n");

            PrintAccountArray(accountsList.ToArray());


            // Testing BAD Arguments

            Console.WriteLine("\n\n*************************************************");
            Console.WriteLine("** Testing Bad Arguments:");
            Console.WriteLine("*************************************************\n");


            Account[] badArray = null;

            try
            {
                AccountSorter.Sort(badArray, 5);  // Null array
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                AccountSorter.Sort(accountsArray, 0); // 0 buckets
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Account> badList = null;

            try
            {
                AccountSorter.Sort(badList, 5); // Null list
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                AccountSorter.Sort(accountsList, 0); // 0 buckets
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\n*************************************************");
            Console.WriteLine("** TESTING END");
            Console.WriteLine("*************************************************");
        }
    }
}
