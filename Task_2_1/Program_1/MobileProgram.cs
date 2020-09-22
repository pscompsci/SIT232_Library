using System;

namespace Program_1
{
    class MobileProgram
    {
        static void Main(string[] args)
        {
            Mobile jimMobile = new Mobile("Monthly", "Samsung Galaxy S6", "07712223344");

            Console.WriteLine("Account Type: " + jimMobile.getAccType() +
                "\nMobile Number: " + jimMobile.getNumber() +
                "\nDevice: " + jimMobile.getDevice() +
                "\nBalance: " + jimMobile.getBalance());


            Console.WriteLine();

            jimMobile.setAccType("PAYG");
            jimMobile.setDevice("iPhone 6S");
            jimMobile.setNumber("07713334466");
            jimMobile.setBalance(15.50);

            Console.WriteLine("Account Type: " + jimMobile.getAccType() +
                "\nMobile Number: " + jimMobile.getNumber() +
                "\nDevice: " + jimMobile.getDevice() +
                "\nBalance: " + jimMobile.getBalance());

            Console.WriteLine();

            jimMobile.addCredit(10.0);
            jimMobile.makeCall(5);
            jimMobile.sendText(2);

            // Create additional mobile account and test
            Console.WriteLine("\nCreating new mobile account for Peter\n");

            Mobile peterMobile = new Mobile("Monthly", "Samsung Galaxy S9+", "0412324124");
            peterMobile.addCredit(50.00);
            peterMobile.makeCall(25);
            peterMobile.sendText(20);

            Console.ReadLine();
        }
    }
}
