using System;

namespace Task02
{
    /// <summary>
    /// Prototype for a penguin as a type of bird
    /// </summary>
    class Penguin : Bird
    {
        /// <summary>
        /// Constructor for a penguin as a type of bird
        /// </summary>
        /// <param name="name">The personal name of the penguin</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the penguin is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the penguin in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of bird</param>
        /// <param name="wingspan">The wingspan in centimetres</param>
        public Penguin(String name, String diet, String location,
            double weight, int age, String colour, String species,
            double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        { }

        /// <summary>
        /// The penguin lays an egg
        /// </summary>
        public void layEgg()
        {
            // code to allow penguins to lay eggs
            Console.WriteLine("{0} lays an egg in the ice.", _name);
        }

        /// <summary>
        /// The penguin eats fish
        /// </summary>
        public override void eat()
        {
            Console.WriteLine("{0} eats 0.5lb of fish", _name);
        }

        /// <summary>
        /// The penguin sleeps
        /// </summary>
        public override void sleep()
        {
            Console.WriteLine("{0} rests in his nest, asleep", _name);
        }

        /// <summary>
        /// The penguin goes nowhere in the air
        /// </summary>
        public override void fly()
        {
            Console.WriteLine("{0} flaps his little wings and goes nowhere", _name);
        }

        /// <summary>
        /// The penguin makes a penguin noise
        /// </summary>
        public override void makeNoise()
        {
            Console.WriteLine("{0} sneezes", _name);
        }

        /// <summary>
        /// The penguin makes it's home
        /// </summary>
        public override void buildHome()
        {
            Console.WriteLine("{0} builds a rookery", _name);
        }
    }
}