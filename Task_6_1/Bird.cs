using System;

namespace Task_6_1P
{
    /// <summary>
    /// Prototype for a Bird and base class for more specific bird classes
    /// </summary>
    class Bird
    {
        // Instance variables
        public string Name { get; set; }

        /// <summary>
        /// Creates a new Bird
        /// </summary>
        public Bird()
        {

        }

        /// <summary>
        /// Allows the bird to fly
        /// </summary>
        public virtual void fly()
        {
            Console.WriteLine("Flap, Flap, Flap");
        }

        /// <summary>
        /// Returns a string representation of a bird
        /// </summary>
        /// <returns>
        /// String representation of a Bird
        /// </returns>
        public override string ToString()
        {
            return "A bird named " + Name;
        }
    }
}
