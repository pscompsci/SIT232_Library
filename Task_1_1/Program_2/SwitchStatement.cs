using System;

namespace Program_2
{
    class SwitchStatement
    {
        static void Main(string[] args)
        {
            int number = 0;

            Console.WriteLine("Enter a number (as an integer): ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: Input was not an integer");
                System.Environment.Exit(1);
            }
            switch (number)
            {
                case 1: Console.WriteLine("One"); break;
                case 2: Console.WriteLine("Two"); break;
                case 3: Console.WriteLine("Three"); break;
                case 4: Console.WriteLine("Four"); break;
                case 5: Console.WriteLine("Five"); break;
                case 6: Console.WriteLine("Six"); break;
                case 7: Console.WriteLine("Seven"); break;
                case 8: Console.WriteLine("Eight"); break;
                case 9: Console.WriteLine("Nine"); break;
                default: Console.WriteLine("ERROR: Number must be from 1-9"); break;
            }

            Console.ReadLine();
        }
    }
}
