using System;

namespace Task_6_1P
{
    /// <summary>
    /// Prototype for a Duck as a type of Bird
    /// </summary>
    class Duck : Bird
    {
        // Instance variables
        public double Size { get; set; }
        public string Kind { get; set; }

        /// <summary>
        /// Returns a string representation of a Duck
        /// </summary>
        /// <returns>
        /// String representation of a Duck
        /// </returns>
        public override string ToString()
        {
            return "A duck named " + Name + " is a " + Size + " inch " + Kind;
        }
    }
}
