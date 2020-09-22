using System;

namespace Program_5
{
    /// <summary>
    /// Calculates recommended cooking time in a microwave
    /// </summary>
    class Microwave
    {
        // Reads String input in the console
        /// <summary>
        /// Reads String input in the console
        /// </summary>
        /// <returns>
        /// The String input of the user
        /// </returns>
        /// <param name="prompt">The String prompt for the user</param>
        public String ReadString(String prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }

        // Reads integer input in the console
        /// <summary>
        /// Reads integerinput in the console
        /// </summary>
        /// <returns>
        /// The input of the user as an integer
        /// </returns>
        /// <param name="prompt">The String prompt for the user</param>
        public int ReadInteger(String prompt)
        {
            int number = 0;
            String numberInput = ReadString(prompt);
            while (!(int.TryParse(numberInput, out number)))
            {
                Console.WriteLine("Please enter a whole number");
                numberInput = ReadString(prompt);
            }
            return Convert.ToInt32(numberInput);
        }

        // Reads double input in the console
        /// <summary>
        /// Reads double input in the console
        /// </summary>
        /// <returns>
        /// The input of the user as a double
        /// </returns>
        /// <param name="prompt">The String prompt for the user</param>
        public double ReadDouble(String prompt)
        {
            double number = 0.0;
            String numberInput = ReadString(prompt);
            while (!(double.TryParse(numberInput, out number)))
            {
                Console.WriteLine("Please enter a number");
                numberInput = ReadString(prompt);
            }
            return Convert.ToDouble(numberInput);
        }

        // Returns the number of items to cook
        /// <summary>
        /// Returns the number of items to cook
        /// </summary>
        /// <returns>
        /// An integer of the number of items
        /// </returns>
        public int NumberOfItems()
        {
            String prompt = "Enter the number of items";
            int items = ReadInteger(prompt);
            while (items < 1)
            {
                Console.WriteLine("Please enter at least 1 item");
                items = ReadInteger(prompt);
            }
            return items;
        }

        // Returns the time in minutes, to cook a single item
        /// <summary>
        /// Returns the time in minutes, to cook a single item
        /// </summary>
        /// <returns>
        /// A double of the cooking time for one item
        /// </returns>
        public double SingleCookingTime()
        {
            String prompt = "Enter the time for one item (minutes)";
            double time = ReadDouble(prompt);
            while (time <= 0.0)
            {
                Console.WriteLine("Please enter a time more than 0.0");
                time = ReadDouble(prompt);
            }
            return time;
        }

        // Returns the recommended cooking time for the number of items
        /// <summary>
        /// Returns the recommended cooking time for the number of items
        /// </summary>
        /// <returns>
        /// A double of the cooking time for the number of items, or -1
        /// if more than 3 items are to be cooked
        /// </returns>
        public double CookingTime(int items, double singleTime)
        {
            switch (items)
            {
                case 1: return singleTime;
                case 2: return singleTime * 1.5;
                case 3: return singleTime * 2;
                default: return -1; // number of items not recommended
            }
        }

        // Outputs recommended cooking time for the number of items
        /// <summary>
        /// Outputs the recommended cooking time for the number of items
        /// </summary>
        public void RecommendedCookingTime()
        {
            int items = NumberOfItems();
            double singleTime = SingleCookingTime();
            double cookingTime = CookingTime(items, singleTime);
            if (cookingTime > -1)
            {
                String output = String.Format("Recommended cooking time: {0} minutes", cookingTime);
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Maximum of 3 items recommended");
            }
        }

        static void Main(String[] args)
        {
            Microwave microwave = new Microwave();
            microwave.RecommendedCookingTime();

            Console.ReadLine();
        }
    }
}
