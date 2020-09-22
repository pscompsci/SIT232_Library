using System;

namespace Program_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 13;
            if (height <= 12)
                Console.WriteLine("Low bridge"); // block braces {} not needed as it's a single line to execute after, but in general is a good idea to include
            else  // added else clause so the output only runs if the height is > 12
                Console.WriteLine("Proceed with caution");

            int sum = 21;
            if (sum != 20)
                Console.Write("You win "); // changed function call to Write, so the message is on one line
            else
                Console.Write("You lose "); // changed function call to Write, so the message is on one line
            Console.WriteLine("the prize"); // Adjusted the format to make clear that this line is not part of the else block. Could also use {} around the blocks

            sum = 7; // not need for int, as its declared above
            if (sum > 20)
            { // reformatted for consistency with normal style
                Console.Write("You win "); // changed function call to Write, so the message is on one line
            }
            else
            {
                Console.Write("You lose "); // changed function call to Write, so the message is on one line
            }
            Console.WriteLine("the prize");
        }
    }
}
