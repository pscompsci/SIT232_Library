using System;

namespace Task_6_1P
{
    /// <summary>
    /// Prototype for a Penguin as a type of Bird
    /// </summary>
    class Penguin : Bird
    {
        /// <summary>
        /// Prevents a Penguin from flying
        /// </summary>
        public override void fly()
        {
            Console.WriteLine("Penguins cannot fly");
        }

        /// <summary>
        /// Returns a string representation of a Penguin
        /// </summary>
        /// <returns>
        /// String representation of a Penguin
        /// </returns>
        public override string ToString()
        {
            return "A penguin named " + Name;
        }
    }
}
