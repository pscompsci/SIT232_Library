using System;

namespace Task02
{
    /// <summary>
    /// Prototype for a tiger as a type of feline
    /// </summary>
    class Tiger : Feline
    {
        private String _colourStripes;

        /// <summary>
        /// Constructor for a tiger as a type of feline
        /// </summary>
        /// <param name="name">The personal name of the tiger</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the tiger is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the tiger in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of tiger</param>
        public Tiger(String name, String diet, String location,
            double weight, int age, String colour, String species,
            String colourStripes)
            : base(name, diet, location, weight, age, colour, species)
        {
            _colourStripes = colourStripes;
        }

        /// <summary>
        /// The tiger eats meat
        /// </summary>
        public override void eat()
        {
            Console.WriteLine("{0}, eats 20lbs of meat", _name);
        }

        /// <summary>
        /// The tiger roars
        /// </summary>
        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRRRRR");
        }

        /// <summary>
        /// The tiger makes it's home in the display
        /// </summary>
        public override void buildHome()
        {
            Console.WriteLine("{0} builds a lair", _name);
        }
    }
}