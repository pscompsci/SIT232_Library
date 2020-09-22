using System;

namespace Program_1
{
    /// <summary>
    /// The mobile class defines attributes and methods on mobile 
    /// phone accounts
    /// </summary>
    class Mobile
    {
        // Instance variables
        private String accType, device, number;
        private double balance;

        // VARIABLES
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;


        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="accType">The account type</param>
        /// <param name="device">The mobile phone make and model</param>
        /// <param name="number">The mobile phone number</param>
        public Mobile(String accType, String device, String number)
        {
            this.accType = accType;
            this.device = device;
            this.number = number;
            this.balance = 0.0;
        }

        /// <summary>
        /// Returns the account type
        /// </summary>
        /// <returns>
        /// The account type
        /// </returns>
        public String getAccType()
        {
            return this.accType;
        }

        /// <summary>
        /// Returns the device details
        /// </summary>
        /// <returns>
        /// The device make and model
        /// </returns>
        public String getDevice()
        {
            return this.device;
        }

        /// <summary>
        /// Returns the mobile phone number
        /// </summary>
        /// <returns>
        /// The the mobile phone number
        /// </returns>
        public String getNumber()
        {
            return this.number;
        }

        /// <summary>
        /// Returns the account credit balance
        /// </summary>
        /// <returns>
        /// The account credit balance in currency format
        /// </returns>
        public String getBalance()
        {
            return this.balance.ToString("C");
        }

        /// <summary>
        /// Sets the account type
        /// </summary>
        /// <param name="accType">The new account type</param>
        public void setAccType(String accType)
        {
            this.accType = accType;
        }

        /// <summary>
        /// Sets the device details
        /// </summary>
        /// <param name="device">The device make and model</param>
        public void setDevice(String device)
        {
            this.device = device;
        }

        /// <summary>
        /// Sets the mobile phone number
        /// </summary>
        /// <param name="number">The new mobile phone number</param>
        public void setNumber(String number)
        {
            this.number = number;
        }

        /// <summary>
        /// Sets the account type
        /// </summary>
        /// <param name="balance">The new balance to set</param>
        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        /// <summary>
        /// Adds credit to the account balance
        /// </summary>
        /// <param name="amount">The amount to credit the account</param>
        public void addCredit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("Credit added successfully. New balance " + getBalance());
        }

        /// <summary>
        /// Calculates the cost of a call by minutes talking and updates
        /// the balance
        /// </summary>
        /// <param name="minutes">The time of the call(s) in minutes</param>
        public void makeCall(int minutes)
        {
            double cost = minutes * CALL_COST;
            this.balance -= cost;
            Console.WriteLine("Call made. New balanace " + getBalance());
        }

        /// <summary>
        /// Calculates the cost of text sent by the number of texts and
        /// updates the balance
        /// </summary>
        /// <param name="numTexts">The number of texts sent</param>
        public void sendText(int numTexts)
        {
            double cost = numTexts * TEXT_COST;
            this.balance -= cost;
            Console.WriteLine("Text Sent. New balance " + getBalance());
        }
    }
}