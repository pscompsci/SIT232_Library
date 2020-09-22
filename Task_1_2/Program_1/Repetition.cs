using System;

namespace Program_1
{
    class Repetition
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;
            int upperbound = 100;

            for (int number = 1; number <= upperbound; number++)
            {
                sum += number;
            }

            average = (double)sum / upperbound;

            Console.WriteLine("The sum is " + sum);
            Console.WriteLine("The average is " + average);

            sum = 0; // reset back to 0 for while loop approach
            average = 0.0; // reset back to 0
            int num = 1;
            while (num <= upperbound)
            {
                sum += num;
                //Console.WriteLine("Current number: " + number + " the sum is " + sum);
                num++;
            }

            average = (double)sum / upperbound;

            Console.WriteLine("The sum is " + sum);
            Console.WriteLine("The average is " + average);

            num = 1;
            sum = 0;
            average = 0.0;
            do
            {
                sum += num;
                num++;
            } while (num <= upperbound);

            average = (double)sum / upperbound;

            Console.WriteLine("The sum is " + sum);
            Console.WriteLine("The average is " + average);

            Console.ReadLine();
        }
    }
}
