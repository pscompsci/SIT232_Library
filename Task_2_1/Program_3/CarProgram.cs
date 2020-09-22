using System;

namespace Program_3
{
    class CarProgram
    {
        static void Main(string[] args)
        {
            // Create a myCar object
            Car myCar = new Car(14.5, 65.5);

            // Test setting total miles, getting total miles and fuel
            myCar.setTotalMiles(100);
            Console.WriteLine("Current mileage: " + myCar.getTotalMiles()
                + ", Current fuel: " + myCar.getFuel());

            // Test adding fuel and printing the fuel cost
            myCar.addFuel(22);
            Console.WriteLine("Current fuel cost per litre: " + myCar.printFuelCost());

            // Test driving
            myCar.drive(60);
            Console.WriteLine("Current mileage: " + myCar.getTotalMiles()
                + ", Current fuel: " + myCar.getFuel());

            // Test driving again to check mileage accumulates correctly
            myCar.drive(30);
            Console.WriteLine("Current mileage: " + myCar.getTotalMiles()
                + ", Current fuel: " + myCar.getFuel());

            Console.ReadLine();
        }
    }
}
