using System;

namespace Task02
{
    /// <summary>
    /// Super class for all cats as a type of animal
    class Feline : Animal
    {
        private String _species;

        /// <summary>
        /// Constructor for an eagle as a type of feline
        /// </summary>
        /// <param name="name">The personal name of the feline</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the feline is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the feline in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of feline</param>
        public Feline(String name, String diet, String location,
            double weight, int age, String colour, String species)
            : base(name, diet, location, weight, age, colour)
        {
            _species = species;
        }

        /// <summary>
        /// Allows a cat to sleep
        /// </summary>
        public override void sleep()
        {
            Console.WriteLine("{0} lays down and goes to sleep", _name);
        }
    }
}