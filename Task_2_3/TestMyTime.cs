using System;

namespace Task_2._3C
{
    class TestMyTime
    {
        static void Main(string[] args)
        {
            int thrown = 0;

            Console.WriteLine("\n*************");
            Console.WriteLine("TESTING START");
            Console.WriteLine("*************");

            // -----------------------------------------------------------------
            // Class instantiation
            // -----------------------------------------------------------------
            MyTime time1 = new MyTime(); // Empty constructor
            MyTime time2 = new MyTime(10, 36, 45); // hour, min, sec

            try
            {
                MyTime time3 = new MyTime(100, 100, 100);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: Constructor: {1}",
                    thrown, ex.Message);  // 1, expect (invalid hour) to be thrown
            }

            /// -----------------------------------------------------------------
            // Property getters
            // -----------------------------------------------------------------
            Console.WriteLine("Property get time1 hour: {0}, min: {1}, sec {2}",
                time1.Hour, time1.Minute, time1.Second); // expect 0, 0 ,0
            Console.WriteLine("Property get time2 hour: {0}, min: {1}, sec {2}",
                time2.Hour, time2.Minute, time2.Second); // expect 10, 36, 45

            // -----------------------------------------------------------------
            // Property setters
            // -----------------------------------------------------------------

            // Reasonable values, no error expected
            try
            {
                time1.Hour = 10;
                time1.Minute = 10;
                time1.Second = 10;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("Property Setters: Should not be thrown, {0}: {1}",
                    thrown, ex.Message);
            }

            // Invalid hour
            try
            {
                time1.Hour = 30;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: Hour Property: {1}",
                    thrown, ex.Message); // 2, expect to be thrown
            }

            // Invalid minute
            try
            {
                time1.Minute = -15;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: Minute Property: {1}",
                    thrown, ex.Message); // 3, expect to be thrown
            }

            // Invalid second
            try
            {
                // time1.Second = "thirty";  // syntax error
                // time1.Second = 13.5;      // syntax error
                time1.Second = 60;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: Second Property: {1}",
                    thrown, ex.Message); // 4, expect to be thrown
            }

            // -----------------------------------------------------------------
            // SetTime
            // -----------------------------------------------------------------

            // SetTime (reasonable values, no error expected)
            try
            {
                time2.SetTime(20, 15, 30);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("SetTime: Should not be thrown {0}: {1}",
                    thrown, ex.Message);
            }

            // SetTime (bad hour)
            try
            {
                time2.SetTime(24, 15, 30);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetTime: {1}", thrown, ex.Message); // 5, expect to be thrown
            }

            // SetTime (bad minute)
            try
            {
                time2.SetTime(20, 60, 30);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetTime: {1}", thrown, ex.Message); // 6, expect to be thrown
            }

            // SetTime (bad second)
            try
            {
                time2.SetTime(20, 15, 100);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetTime: {1}", thrown, ex.Message); // 7, expect to be thrown
            }

            // -----------------------------------------------------------------
            // SetHour
            // -----------------------------------------------------------------

            // Reasonable value, no error expected
            try
            {
                time1.SetHour(20);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("SetHour: Should not be thrown {0}: {1}",
                    thrown, ex.Message);
            }

            // SetTime (bad hour)
            try
            {
                time1.SetHour(70);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetHour: {1}", thrown, ex.Message); // 8, expect to be thrown
            }

            // -----------------------------------------------------------------
            // SetMinute
            // -----------------------------------------------------------------

            // Reasonable value, no error expected
            try
            {
                time1.SetMinute(20);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("SetMinute: Should not be thrown {0}: {1}",
                    thrown, ex.Message);
            }

            // SetTime (bad minute)
            try
            {
                time1.SetMinute(70);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetMinute: {1}", thrown, ex.Message); // 9, expect to be thrown
            }

            // -----------------------------------------------------------------
            // SetSecond
            // -----------------------------------------------------------------

            // Reasonable value, no error expected
            try
            {
                time1.SetSecond(20);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("SetSecond: Should not be thrown {0}: {1}",
                    thrown, ex.Message);
            }

            // SetTime (bad second)
            try
            {
                time1.SetSecond(70);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                thrown++;
                Console.WriteLine("ERROR {0}: SetSecond: {1}", thrown, ex.Message); // 10, expect to be thrown
            }

            // -----------------------------------------------------------------
            // GetHour, GetMinute, GetSecond
            // -----------------------------------------------------------------
            time2.SetTime(10, 20, 30);

            int hour = time2.GetHour();
            int minute = time2.GetMinute();
            int second = time2.GetSecond();

            Console.WriteLine("GetHour, GetMinute, GetSecond: Expect 10:20:30 - {0}:{1}:{2}",
                hour, minute, second);

            // -----------------------------------------------------------------
            // ToString
            // Also tests Format
            // -----------------------------------------------------------------
            time1.SetTime(1, 2, 3);
            Console.WriteLine("ToString: Expect 01:02:03 - Result {0}", time1.ToString());

            time2.SetTime(10, 5, 35);
            Console.WriteLine("ToString: Expect 10:05:35 - Result {0}", time2.ToString());

            // -----------------------------------------------------------------
            // NextSecond, NextMinute, NextHour
            // Also tests Format
            // -----------------------------------------------------------------
            time1.SetTime(23, 59, 55);

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                time1.NextSecond();
                Console.WriteLine(time1.ToString());
            }

            // -----------------------------------------------------------------
            // PreviousSecond, PreviousMinute, PreviousHour
            // Also tests Format
            // -----------------------------------------------------------------
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                time1.PreviousSecond();
                Console.WriteLine(time1.ToString());
            }

            Console.WriteLine("\n***********");
            Console.WriteLine("TESTING END");
            Console.WriteLine("***********\n");
        }
    }
}
