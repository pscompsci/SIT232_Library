using System;

namespace Task02
{
    /// <summary>
    /// Prototype for a lion as a type of feline
    /// </summary>
    class Lion : Feline
    {
        /// <summary>
        /// Constructor for a lion as a type of feline
        /// </summary>
        /// <param name="name">The personal name of the lion</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the lion is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the lion in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of lion</param>
        public Lion(String name, String diet, String location,
            double weight, int age, String colour, String species)
            : base(name, diet, location, weight, age, colour, species)
        { }

        /// <summary>
        /// The lion eats
        /// </summary>
        public override void eat()
        {
            Console.WriteLine("{0} eats 50lbs of meat", _name);
        }

        /// <summary>
        /// The lion roars bigly
        /// </summary>
        public override void makeNoise()
        {
            Console.WriteLine("BIIIIGGGG ROARRRRRRRRRRR");
        }

        /// <summary>
        /// The lion builds the location for it's pride in the display
        /// </summary>
        public override void buildHome()
        {
            Console.WriteLine("{0} builds a den", _name);
        }
    }
}