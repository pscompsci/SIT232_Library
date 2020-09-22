using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_3._4D
{
    static class AccountSorter
    {
        /// <summary>
        /// Returns the maximum account balance from an array of accounts
        /// </summary>
        /// <returns>
        /// The maximum account balance as a decimal
        /// </returns>
        /// <param name="accounts">The array of accounts</param>
        private static decimal MaximumBalance(Account[] accounts)
        {
            return accounts.Max(a => a.Balance);
        }

        /// <summary>
        /// Creates and initializes required list of buckets
        /// </summary>
        /// <returns>
        /// Array of buckets containing a list to store accounts
        /// </returns>
        /// <param name="b">The number of buckets required</param>
        private static List<Account>[] CreateBuckets(int b)
        {
            List<Account>[] buckets = new List<Account>[b];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<Account>();
            }
            return buckets;
        }

        /// <summary>
        /// Distributes accounts into buckets from the array of accounts
        /// </summary>
        /// <param name="accounts">The array of accounts to distribute</param>
        /// <param name="buckets">The array of buckets to distribute into</param>
        private static void DistributeAccounts(Account[] accounts, List<Account>[] buckets)
        {
            decimal maximum = MaximumBalance(accounts);
            foreach (Account account in accounts)
            {
                int bucket = (int)(Math.Floor(buckets.Length * account.Balance / maximum));
                if (bucket == buckets.Length)
                    bucket -= 1;
                buckets[bucket].Add(account);
            }
        }

        /// <summary>
        /// Sorts the accounts in each bucket by account balance
        /// </summary>
        /// <param name="buckets">The buckets holding accounts</param>
        private static void SortBuckets(List<Account>[] buckets)
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = buckets[i].OrderBy(a => a.Balance).ToList();
            }
        }

        /// <summary>
        /// Sorts an array of accounts by their account balance from
        /// smallest to largest
        /// </summary>
        /// <param name="accounts">The array of accounts to sort</param>
        /// <param name="b">The number of buckets to use</param>
        /// <exception cref="System.NullReferenceException">Thrown
        /// if the accounts array is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// if the number of buckets is 0 or less</exception>
        public static void Sort(Account[] accounts, int b)
        {
            if (accounts == null)
            {
                throw new NullReferenceException("Accounts cannot be null");
            }

            if (b <= 1)
            {
                throw new ArgumentOutOfRangeException("At least 2 buckets needed");
            }

            List<Account>[] buckets = CreateBuckets(b);
            DistributeAccounts(accounts, buckets);
            SortBuckets(buckets);

            // Write the accounts in the buckets back into the original
            // accounts array. Idx tracks the position in the
            // original accounts array to write to
            int idx = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                foreach (Account account in buckets[i])
                {
                    accounts[idx] = account;
                    idx++;
                }
            }
        }

        /// <summary>
        /// Sorts a list of accounts by their account balance from
        /// smallest to largest
        /// </summary>
        /// <param name="accounts">The list of accounts to sort</param>
        /// <param name="b">The number of buckets to use</param>
        /// <exception cref="System.NullReferenceException">Thrown
        /// if the accounts list is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// if the number of buckets is 0 or less</exception>
        public static void Sort(List<Account> accounts, int b)
        {
            if (accounts == null)
            {
                throw new NullReferenceException("Accounts cannot be null");
            }

            Account[] accountsArray = accounts.ToArray();
            Sort(accountsArray, b);

            // Write the accountsArray back into the accounts list.
            // Cannot simply call .ToList() as order is not guaranteed.
            for (int i = 0; i < accounts.Count; i++)
            {
                accounts[i] = accountsArray[i];
            }
        }
    }
}
