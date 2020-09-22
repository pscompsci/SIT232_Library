using System;

namespace Program_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // !Code Section 1
            int c = 0, product = 0;
            while (c <= 5)
            { // defined code block with curly braces
                product = product * 5;
                c = c + 1;
            }
            Console.WriteLine("Product: " + product);

            // !Code Section 2
            int a = 31, b = 0, sum = 0;
            while (a > b) // initial test would never be true for odd 'a'
            {
                sum = sum + a;
                b = b + 2;
            }
            Console.WriteLine("Sum: " + sum);

            // !Code Section 3
            int x = 1;
            int total = 0; // unassigned variable can't be used in calculation
            while (x <= 10)
            {
                total = total + x;
                x = x + 1;
            }
            Console.WriteLine("Total: " + total);

            // !Code Section 4
            int y = 0; // y declared inside the block, so reset every loop, causing infinite loop
            while (y < 10)
            {
                Console.WriteLine("y" + y);
                y = y + 1;
            }

            // !Code Section 5
            int z = 0; // while loop will never execute as pre-loop test is false
            while (z > 0)
            {
                z = z - 1;
                Console.WriteLine("z: " + z);
            }

            // !Code Section 6
            for (int count = 1; count < 100; count++) // Commas: incorrect syntax
            {
                Console.WriteLine("Hello");
            }

            // !Code Section 7
            for (int i = 1; i < 10; i++) // incorrect case (I vs i) and test ends up in loop never executing due to test (> instead of <) 
            {
                Console.WriteLine("Flower");
            }
        }
    }
}
