using System;

namespace Task02
{
    /// <summary>
    /// Prototype for a bird as type of animal
    /// </summary>
    class Bird : Animal
    {
        // Instance variables
        private String _species;
        private double _wingSpan;

        /// <summary>
        /// Constructor for a bird instance
        /// </summary>
        /// <param name="name">The personal name of the bird</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the bird is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the bird in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of bird</param>
        /// <param name="wingspan">The wingspan in centimetres</param>
        public Bird(String name, String diet, String location,
            double weight, int age, String colour, String species, double wingSpan)
            : base(name, diet, location, weight, age, colour)
        {
            _species = species;
            _wingSpan = wingSpan;
        }

        /// <summary>
        /// Allows the bird to sleep
        /// </summary>
        public override void sleep()
        {
            Console.WriteLine("{0} lays down and goes to sleep", _name);
        }

        /// <summary>
        /// Message posted when the bird tries to fly
        /// </summary>
        public virtual void fly()
        {
            // code to allow eagles to fly
            Console.WriteLine("{0} thinks about flying", _name);
        }
    }
}