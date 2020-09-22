using System;

namespace Program_6
{
    class DoCasting
    {
        static void Main(string[] args)
        {
            int sum = 17;
            int count = 5;

            int intAverage = sum / count;
            Console.WriteLine(intAverage); // average is integer division and not precise

            double doubleAverage = 0.0;
            doubleAverage = sum / count;
            Console.WriteLine(doubleAverage); // still integer division and not precise answer

            doubleAverage = (double)sum / count;
            Console.WriteLine(doubleAverage); // Now more precise as the division now uses doubles
        }
    }
}
