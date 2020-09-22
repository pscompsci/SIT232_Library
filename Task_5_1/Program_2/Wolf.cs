using System;

namespace Task02
{
    class Wolf : Animal
    {
        /// <summary>
        /// Constructor for a wolf as a type of animal
        /// </summary>
        /// <param name="name">The personal name of the wolf</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the wolf is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the wolf in years</param>
        /// <param name="colour">The dominant color(s)</param>
        public Wolf(String name, String diet, String location,
            double weight, int age, String colour)
            : base(name, diet, location, weight, age, colour)
        { }

        /// <summary>
        /// The wolf eats meat
        /// </summary>
        public override void eat()
        {
            Console.WriteLine("{0} eats 10lbs of meat", _name);
        }

        /// <summary>
        /// The wolf sleeps
        /// </summary>
        public override void sleep()
        {
            Console.WriteLine("{0} settles down in his den and sleeps", _name);
        }

        /// <summary>
        /// The wolf howls
        /// </summary>
        public override void makeNoise()
        {
            Console.WriteLine("{0} howls", _name);
        }

        /// <summary>
        /// The wolf makes it's den
        /// </summary>
        public override void buildHome()
        {
            Console.WriteLine("{0} builds a den", _name);
        }
    }
}