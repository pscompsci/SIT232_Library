using System;

namespace Task01
{
    class Animal
    {
        // Instance variables
        private String _name;
        private String _diet;
        private String _location;
        private double _weight;
        private int _age;
        private String _colour;

        /// <summary>
        /// Constructor for an animal
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
        public void eat()
        {
            // Code for the animal to eat
            Console.WriteLine("The animal eats food");
        }

        /// <summary>
        /// Method to make the animal sleep
        /// </summary>
        public void sleep()
        {
            // Code for the animal to sleep
            Console.WriteLine("The animal sleeps");
        }

        /// <summary>
        /// Method to make the animal make a noise
        /// </summary>
        public void makeNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The animal makes a noise");
        }

        /// <summary>
        /// Method to make any animal sound like a lion
        /// </summary>
        public void makeLionNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The Lion makes a noise");
        }

        /// <summary>
        /// Method to make any animal sound like an eagle
        /// </summary>
        public void makeEagleNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The eagle makes a noise");
        }

        /// <summary>
        /// Method to make any animal sound like a wolf
        /// </summary>
        public void makeWolfNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The wolf makes a noise");
        }

        /// <summary>
        /// Method to make an animal eat meat
        /// </summary>
        public void eatMeat()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The animal eats meat");
        }

        /// <summary>
        /// Method to make an animal eat berries
        /// </summary>
        public void eatBerries()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The animal eats berries");
        }

        /// <summary>
        /// Method to make an animal eat fish
        /// </summary>
        public void eatFish()
        {
            // Code for the animal to make a noise
            Console.WriteLine("The animal eats fish");
        }
    }
}
