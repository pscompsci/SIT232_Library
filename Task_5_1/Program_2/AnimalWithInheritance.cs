using System;

namespace Task02
{
    /// <summary>
    /// Base class for all animals
    /// </summary>
    class Animal
    {
        // Instance variables
        protected String _name;
        protected String _diet;
        protected String _location;
        protected double _weight;
        protected int _age;
        protected String _colour;

        /// <summary>
        /// Constructor for a base animal instance
        /// </summary>
        /// <param name="name">The personal name of the animal</param>
        /// <param name="diet">The primary type of food eaten</param>
        /// <param name="location">The exhibition the animal is in</param>
        /// <param name="weight">Weight in pounds</param>
        /// <param name="age">Age of the animal in years</param>
        /// <param name="colour">The dominant color(s)</param>
        public Animal(String name, String diet, String location,
            double weight, int age, String colour)
        {
            _name = name;
            _diet = diet;
            _location = location;
            _weight = weight;
            _age = age;
            _colour = colour;
        }

        /// <summary>
        /// Method to make the animal eat food
        /// </summary>
        public virtual void eat()
        {
            // code for animal to eat
            Console.WriteLine("An animal eats");
        }

        /// <summary>
        /// Puts the animal to sleep
        /// </summary>
        public virtual void sleep()
        {
            // code for animal to sleep
            Console.WriteLine("An animal sleeps");
        }

        /// <summary>
        /// Allows the animal to speak or make noise
        /// </summary>
        public virtual void makeNoise()
        {
            // code for animal to make a noise
            Console.WriteLine("An animal makes a noise");
        }

        /// <summary>
        /// Allows the animal to construct it's home within the display
        /// </summary>
        public virtual void buildHome()
        {
            Console.WriteLine("An animal builds a home");
        }
    }
}
