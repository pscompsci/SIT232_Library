using System;

namespace Program_3
{
    /// <summary>
    /// Defines properties and methods to track car mileage, fuel and cost
    /// </summary>
    class Car
    {
        // Instance variables
        private double fuelEfficiency;
        private double fuelLevel;
        private int mileage;

        // VARIABLES
        double FUEL_COST = 1.385;
        double GALLONS_TO_LITRES = 4.546;

        /// <summary>
        /// Class constructor
        /// </summary>
        public Car(double efficiency, double fuel)
        {
            this.fuelEfficiency = efficiency;
            this.fuelLevel = fuel;
            this.mileage = 0;
        }

        /// <summary>
        /// Returns the current fuel in litres
        /// </summary>
        /// <returns>
        /// The current fuel in litres
        /// </returns>
        public double getFuel()
        {
            return this.fuelLevel;
        }

        /// <summary>
        /// Returns the total mileage
        /// </summary>
        /// <returns>
        /// The current mileage of the car
        /// </returns>
        public int getTotalMiles()
        {
            return this.mileage;
        }

        /// <summary>
        /// Sets the total mileage
        /// </summary>
        /// <param name="miles">The total miles to set</param>
        public void setTotalMiles(int miles)
        {
            this.mileage = miles;
        }

        /// <summary>
        /// Returns the cost of fuel in currency format
        /// </summary>
        /// <returns>
        /// The current cost of fuel
        /// </returns>
        public String printFuelCost()
        {
            return this.FUEL_COST.ToString("C");
        }

        /// <summary>
        /// Returns the total cost of fuel use
        /// </summary>
        /// <returns>
        /// The total cost of using an amount of fuel
        /// </returns>
        /// <param name="fuelLitres">The litres of fuel used</param>
        public double calcCost(double fuelLitres)
        {
            return fuelLitres * this.FUEL_COST;
        }

        /// <summary>
        /// Adds fuel to the fuel tank
        /// </summary>
        /// <param name="fuelLitres">Volume of fuel in litres</param>
        public void addFuel(double fuelLitres)
        {
            this.fuelLevel += fuelLitres;
            double fillCost = calcCost(fuelLitres);
            Console.WriteLine("Cost of fill: "
                + calcCost(fuelLitres).ToString("C"));
        }

        /// <summary>
        /// Converts fuel volume from gallons to litres
        /// </summary>
        /// <returns>
        /// The volume of fuel in litres
        /// </returns>
        /// <param name="gallons">The gallons of fuel to convert</param>
        public double convertToLitres(double gallons)
        {
            return gallons * this.GALLONS_TO_LITRES;
        }

        /// <summary>
        /// Calculates and outputs the cost of a trip and updates car
        /// properties
        /// </summary>
        /// <param name="milesTravelled">The total miles travelled</param>
        public void drive(int milesTravelled)
        {
            this.mileage += milesTravelled; // accumulate mileage
            double gallonsUsed = milesTravelled / this.fuelEfficiency;
            double litresUsed = convertToLitres(gallonsUsed);
            this.fuelLevel -= litresUsed; // remove fuel from the tank
            double tripCost = calcCost(litresUsed);
            Console.WriteLine("Total cost of travelling "
                + milesTravelled + " miles = "
                + tripCost.ToString("C"));
        }
    }
}