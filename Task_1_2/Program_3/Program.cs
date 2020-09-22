using System;

namespace Program_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // !Task exercise 5
            int sum = 0;
            for (int j = -5; sum <= 350; j += 5)
            {
                sum += j;
            }
            Console.WriteLine("Sum reached");

            for (int x = 0; x < 500; x += 5)
            {
                Console.WriteLine(x);
            }
        }
    }
}
