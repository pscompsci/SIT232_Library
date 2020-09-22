using System;

namespace Program_3
{
    class Overloading
    {
        public static void methodToBeOverloaded(String name)
        {
            Console.WriteLine("Name: " + name);
        }

        public static void methodToBeOverloaded(String name, int age)
        {
            Console.WriteLine("Name: " + name + "\nAge: " + age);
        }

        static void Main(string[] args)
        {
            methodToBeOverloaded("John Doe");
            methodToBeOverloaded("Jane Doe", 24);
        }
    }
}
