using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._1P
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                        // *****************************************************************
                        // PART 1: STEP 1
                        // *****************************************************************
                        // declares an array of type double with 10 elements
                        double[] myArray = new double[10];

                        // assigning the first element of the array
                        myArray[0] = 1.0;

                        // assigning the second element of the array
                        myArray[1] = 1.1;

                        // assigning the third element of the array
                        myArray[2] = 1.2;

                        // assigning the fourth element of the array
                        myArray[3] = 1.3;

                        // assigning the fifth element of the array
                        myArray[4] = 1.4;

                        // assigning the sixth element of the array
                        myArray[5] = 1.5;

                        // assigning the seventh element of the array
                        myArray[6] = 1.6;

                        // assigning the eighth element of the array
                        myArray[7] = 1.7;

                        // assigning the ninth element of the array
                        myArray[8] = 1.8;

                        // assigning the tenth element of the array
                        myArray[9] = 1.9;

                        // *****************************************************************
                        // PART 1: STEP 2
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 1");
                        Console.WriteLine("*****************************************************************\n");

                        Console.WriteLine("The element at index 0 in the array is " + myArray[0]);
                        Console.WriteLine("The element at index 1 in the array is " + myArray[1]);
                        Console.WriteLine("The element at index 2 in the array is " + myArray[2]);
                        Console.WriteLine("The element at index 3 in the array is " + myArray[3]);
                        Console.WriteLine("The element at index 4 in the array is " + myArray[4]);
                        Console.WriteLine("The element at index 5 in the array is " + myArray[5]);
                        Console.WriteLine("The element at index 6 in the array is " + myArray[6]);
                        Console.WriteLine("The element at index 7 in the array is " + myArray[7]);
                        Console.WriteLine("The element at index 8 in the array is " + myArray[8]);
                        Console.WriteLine("The element at index 9 in the array is " + myArray[9]);

                        // *****************************************************************
                        // PART 2: STEP 1
                        // *****************************************************************
                        int[] myIntArray = new int[10];

                        for (int i = 0; i < myIntArray.Length; i++)
                        {
                            myIntArray[i] = i;
                        }

                        // *****************************************************************
                        // PART 2: STEP 2
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 2");
                        Console.WriteLine("*****************************************************************\n");

                        for (int i = 0; i < myIntArray.Length; i++)
                        {
                            Console.WriteLine("The element at position {0} is {1}",
                                i, myIntArray[i]);
                        }

                        // *****************************************************************
                        // PART 3
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 3");
                        Console.WriteLine("*****************************************************************\n");

                        int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
                        int total = 0;

                        for (int i = 0; i < studentArray.Length; i++)
                        {
                            total += studentArray[i];
                        }

                        Console.WriteLine("The total marks for the student is " + total);
                        Console.WriteLine("This consists of " + studentArray.Length + " marks");
                        Console.WriteLine("Therefore the average mark is "
                            + (total / studentArray.Length));

                        // *****************************************************************
                        // PART 4
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 4");
                        Console.WriteLine("*****************************************************************\n");

                        String[] studentNames = new String[6];

                        for (int i = 0; i < studentNames.Length; i++)
                        {
                            Console.Write("Student {0} name: ", i + 1);
                            studentNames[i] = Console.ReadLine();
                        }

                        for (int i = 0; i < studentNames.Length; i++)
                        {
                            Console.WriteLine("Student {0}: {1}", i + 1, studentNames[i]);
                        }

                        // *****************************************************************
                        // PART 5
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 5");
                        Console.WriteLine("*****************************************************************\n");

                        double[] values = new double[10];
                        double currentLargest, currentSmallest;

                        for (int i = 0; i < values.Length; i++)
                        {
                            Console.Write("Enter a double for position {0}: ", i);
                            String input = Console.ReadLine();
                            // Note - no error checking. Expects valid input only
                            values[i] = Convert.ToDouble(input);
                        }

                        currentLargest = values[0];

                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i] > currentLargest)
                                currentLargest = values[i];
                            Console.WriteLine(values[i]);
                        }

                        Console.WriteLine("The largest value is " + currentLargest);

                        currentSmallest = values[0];

                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i] < currentSmallest)
                                currentSmallest = values[i];
                        }

                        Console.WriteLine("The smallest value is " + currentSmallest);

                        // *****************************************************************
                        // PART 6
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 6");
                        Console.WriteLine("*****************************************************************\n");

                        int[,] myMultiArray = new int[3, 4] { { 1, 2, 3, 4 },
                                                              { 1, 1, 1, 1 },
                                                              { 2, 2, 2, 2 } };

                        for (int i = 0; i < myMultiArray.GetLength(0); i++)
                        {
                            for (int j = 0; j < myMultiArray.GetLength(1); j++)
                            {
                                Console.Write(myMultiArray[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }

                        List<String> myStudentList = new List<string>();

                        Random randomValue = new Random();
                        int randomNumber = randomValue.Next(1, 12);

                        Console.WriteLine("You now need to add all " + randomNumber
                            + " students to your class list");

                        for (int i = 0; i < randomNumber; i++)
                        {
                            Console.Write("Please enter the name of Student " + (i + 1) + ": ");
                            myStudentList.Add(Console.ReadLine());
                            Console.WriteLine();
                        }

                        // *****************************************************************
                        // PART 7
                        // *****************************************************************
                        Console.WriteLine("\n*****************************************************************");
                        Console.WriteLine("** Question 7");
                        Console.WriteLine("*****************************************************************\n");

                        int FuncOne(int[] values)
                        {
                            if (values.Length <= 10)
                            {
                                return GetOddProduct(values);
                            }
                            else
                            {
                                return NumberOfEvens(values);
                            }
                        }

                        int GetOddProduct(int[] values)
                        {
                            int oddProduct = 1;
                            for (int i = 0; i < values.Length; i++)
                            {
                                if (values[i] % 2 == 1)
                                    oddProduct *= values[i];
                            }
                            return oddProduct;
                        }

                        int NumberOfEvens(int[] values)
                        {
                            int numberOfEvens = 0;
                            for (int i = 0; i < values.Length; i++)
                            {
                                if (values[i] % 2 == 0)
                                    numberOfEvens++;
                            }
                            return numberOfEvens;
                        }


                        int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                        // Expect 9 elements, odd product = 1*3*5*7*9=945
                        Console.WriteLine("Result from FuncOne for array of {0} elements: {1}",
                            numArray.Length, FuncOne(numArray));

                        int[] numArray2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                        // Expect 12 elements, number of evens = 2,4,6,8,10,12 = 6
                        Console.WriteLine("Result from FuncOne for array of {0} elements: {1}",
                            numArray2.Length, FuncOne(numArray2));
*/
            // *****************************************************************
            // PART 8
            // *****************************************************************
            Console.WriteLine("\n*****************************************************************");
            Console.WriteLine("** Question 8");
            Console.WriteLine("*****************************************************************\n");

            void FuncTwo(List<double> values)  // list is passed in by reference, so we can modify it
            {
                double average = values.Average();
                for (int i = 0; i < values.Count; i++)
                {
                    values[i] -= average;
                }
            }

            List<double> myList = new List<double>() { 1.0, 2.0, 3.0, 4.0, 5.0 };

            decimal av = (decimal)myList.Average();
            Console.WriteLine("The average is " + av);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + "\t");
            }
            Console.WriteLine();

            FuncTwo(myList);

            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write(myList[i] + "\t");
            }
            Console.WriteLine();

            // *****************************************************************
            // PART 9
            // *****************************************************************
            Console.WriteLine("\n*****************************************************************");
            Console.WriteLine("** Question 9");
            Console.WriteLine("*****************************************************************\n");

            int[] FuncThree(int[,] values)
            {
                List<int> result = new List<int>();
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        if (values[i, j] % 3 == 0)
                            result.Add(values[i, j]);
                    }
                }
                return result.ToArray();
            }

            int[,] myMulti = { { 1,  2,  3,  4 , 5 },
                               { 6,  7,  8,  9, 10 },
                               {11, 12, 13, 14, 15 } };

            int[] mySingle = FuncThree(myMulti);

            for (int i = 0; i < mySingle.Length; i++)
            {
                // Expected result 6, 12, 3, 9, 15
                Console.WriteLine(mySingle[i]);
            }


            // *****************************************************************
            // PART 10
            // *****************************************************************
            Console.WriteLine("\n*****************************************************************");
            Console.WriteLine("** Question 10");
            Console.WriteLine("*****************************************************************\n");

            int[,] FuncFour(int[] values)
            {
                int[,] result = new int[values.Length, 10];
                for (int i = 0; i < values.Length; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        result[i, j - 1] = values[i] * j;
                    }
                }
                return result;
            }

            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[,] result = FuncFour(intArray);

            Console.WriteLine("  \t|1\t2\t3\t4\t5\t6\t7\t8\t9\t10");
            Console.WriteLine("------------------------------------------------------------------------------------");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.Write(intArray[i] + "\t|");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            intArray = new int[] { 5, 10, 15, 20, 25 };
            result = FuncFour(intArray);

            Console.WriteLine("  \t|1\t2\t3\t4\t5\t6\t7\t8\t9\t10");
            Console.WriteLine("------------------------------------------------------------------------------------");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.Write(intArray[i] + "\t|");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
