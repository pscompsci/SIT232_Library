using System;

namespace Program_3
{
    public class Score
    {
        static void Main(string[] args)
        {
            int number = 50;
            if (number == 50)
            {  // Misplaced semi-colon removed
                Console.WriteLine("Number is 50");
            }

            number = 60; // redeclaration of int removed
            if (number >= 50 && number <= 100)
            { // and changed to &&, test conditions (>== and <==) fixed
                Console.WriteLine("Number is more than or equal to 50 and less than or equal to 100");
            }

            double score = 40;
            if (score >= 40)
            {  // parentheses added around the if condition. Added >= to include test score == 40
                Console.WriteLine("You passed the exam!");
            }
            else if (score < 40)
            {
                Console.WriteLine("You failed the exam!");
            }

            int n = 1; // added declaration of n
            switch (n)
            {
                case 1: Console.WriteLine("The number is 1"); break; // added break to prevent falling into next case also
                case 2: Console.WriteLine("The number is 2"); break; // removed space after call to WriteLine for consistency
                default:
                    Console.WriteLine("The number if not 1 or 2"); // removed space after call to WriteLine for consistency
                    break;
            }

            switch (n)
            {
                case 1: Console.WriteLine("A"); break; // corrected casing of "Case"
                case 2: Console.WriteLine("B"); break; // added space between keyword "case" and the condition
                default: Console.WriteLine("C"); break; // corrected casing of "Default"
            }
        }
    }
}
