using System;

namespace Task02
{
    /// <summary>
    /// Prototype for an eagle as a type of bird
    /// </summary>
    class Eagle : Bird
    {

        /// <summary>
        /// Constructor for an eagle as a type of bird
        /// </summary>
        /// <param name="name">The personal name of the eagle</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the eagle is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the eagle in years</param>
        /// <param name="colour">The dominant color(s)</param>
        /// <param name="species">The species of bird</param>
        /// <param name="wingspan">The wingspan in centimetres</param>
        public Eagle(String name, String diet, String location,
            double weight, int age, String colour, String species,
            double wingSpan)
            : base(name, diet, location, weight, age, colour, species, wingSpan)
        { }

        /// <summary>
        /// Allows the eagle to roost in it's nest by laying an egg
        /// </summary>
        public void layEgg()
        {
            // code to allow eagles to lay eggs
            Console.WriteLine("{0} lays an egg. That's a feat of evolution", _name);
        }

        /// <summary>
        /// The eagle flies
        /// </summary>
        public override void fly()
        {
            // code to allow eagles to fly
            Console.WriteLine("{0} spreads his wings and flies", _name);
        }

        /// <summary>
        /// The eagle eats food
        /// </summary>
        public override void eat()
        {
            Console.WriteLine("{0} eats 1lb of fish", _name);
        }

        /// <summary>
        /// The eagle sleeps in it's nest
        /// </summary>
        public override void sleep()
        {
            Console.WriteLine("{0} rests in his nest, asleep", _name);
        }

        /// <summary>
        /// The eagle squarks
        /// </summary>
        public override void makeNoise()
        {
            Console.WriteLine("{0} squarks", _name);
        }

        /// <summary>
        /// The eagle builds it's nest
        /// </summary>
        public override void buildHome()
        {
            Console.WriteLine("{0} builds a nest", _name);
        }
    }
}