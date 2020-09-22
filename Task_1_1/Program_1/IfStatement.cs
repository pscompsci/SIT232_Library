using System;

namespace Task_1._1P
{
    class IfStatement
    {
        static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Enter the number (as an integer): ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) // Thrown for non-integer input
            {
                Console.WriteLine("ERROR: Input was not a number");
                System.Environment.Exit(1);
            }

            if (number == 1)
            {
                Console.WriteLine("ONE");
            }
            else if (number == 2)
            {
                Console.WriteLine("TWO");
            }
            else if (number == 3)
            {
                Console.WriteLine("THREE");
            }
            else if (number == 4)
            {
                Console.WriteLine("FOUR");
            }
            else if (number == 5)
            {
                Console.WriteLine("FIVE");
            }
            else if (number == 6)
            {
                Console.WriteLine("SIX");
            }
            else if (number == 7)
            {
                Console.WriteLine("SEVEN");
            }
            else if (number == 8)
            {
                Console.WriteLine("EIGHT");
            }
            else if (number == 9)
            {
                Console.WriteLine("NINE");
            }
            else
            {
                Console.WriteLine("ERROR: Number must be from 1-9");
            }
        }
    }
}
