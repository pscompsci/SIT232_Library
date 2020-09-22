using System;

namespace Task_2._3C
{
    class MyTime
    {
        // Instance variables
        private int _hour;
        private int _minute;
        private int _second;

        /// Reference for this approach, from:
        /// https://stackoverflow.com/questions/56197825
        public int Hour
        {
            get => _hour;
            set => _hour = (value >= 0) && (value <= 23)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid hour. Must be 0-23");
        }

        public int Minute
        {
            get => _minute;
            set => _minute = (value >= 0) && (value <= 59)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid minute. Must be 0-59");
        }

        public int Second
        {
            get => _second;
            set => _second = (value >= 0) && (value <= 59)
                ? value
                : throw new ArgumentOutOfRangeException("Invalid second. Must be 0-59");
        }

        /// <summary>
        /// Constructor to create new time with 0 values
        /// </summary>
        public MyTime() { }

        /// <summary>
        /// Constructor to create a time with hour, minute and second
        /// </summary>
        /// <param name="hour">Hour in the range 0-23</param>
        /// <param name="minute">Minute in the range 0-59</param>
        /// <param name="second">Second in the range 0-59</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when one of the parameters is outside the range</exception>
        public MyTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// Sets a time with hour, minute and second
        /// </summary>
        /// <param name="hour">Hour in the range 0-23</param>
        /// <param name="minute">Minute in the range 0-59</param>
        /// <param name="second">Second in the range 0-59</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when one of the parameters is outside the range</exception>
        public void SetTime(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        /// <summary>
        /// Sets the hour of a time
        /// </summary>
        /// <param name="hour">Hour in the range 0-23</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when hour is outside the range 0-23</exception>
        public void SetHour(int hour)
        {
            Hour = hour;
        }

        /// <summary>
        /// CSets the minute of a time
        /// </summary>
        /// <param name="minute">Minute in the range 0-59</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when minute is outside the range 0-59</exception>
        public void SetMinute(int minute)
        {
            Minute = minute;
        }

        /// <summary>
        /// Sets the second of a time
        /// </summary>
        /// <param name="second">Second in the range 0-59</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown
        /// when second is outside the range 0-59</exception>
        public void SetSecond(int second)
        {
            Second = second;
        }

        /// <summary>
        /// Gets the hour of a time
        /// </summary>
        /// <returns>
        /// The hour of the time
        /// </returns>
        public int GetHour()
        {
            return _hour;
        }

        /// <summary>
        /// Gets the minute of a time
        /// </summary>
        /// <returns>
        /// The minute of the time
        /// </returns>
        public int GetMinute()
        {
            return _minute;
        }

        /// <summary>
        /// Gets the second of a time
        /// </summary>
        /// <returns>
        /// The second of the time
        /// </returns>
        public int GetSecond()
        {
            return _second;
        }

        /// <summary>
        /// Formats a number to two digits with leading 0 if needed
        /// </summary>
        /// <returns>
        /// The formatted string
        /// </returns>
        /// <param name="value">The integer to format as a 2-digit string</param>
        private String Format(int value)
        {
            return value < 10 ? "0" + value : value.ToString();
        }

        public override String ToString()
        {
            return Format(_hour) + ":" + Format(_minute) + ":" + Format(_second);
        }

        /// <summary>
        /// Advances a time by 1 second
        /// </summary>
        public MyTime NextSecond()
        {
            try
            {
                Second += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Second = 0;
                NextMinute();
            }
            return this;
        }

        /// <summary>
        /// Advances a time by 1 minute
        /// </summary>
        public MyTime NextMinute()
        {
            try
            {
                Minute += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Minute = 0;
                NextHour();
            }
            return this;
        }

        /// <summary>
        /// Advances a time by 1 hour
        /// </summary>
        public MyTime NextHour()
        {
            try
            {
                Hour += 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Hour = 0;
            }
            return this;
        }

        /// <summary>
        /// Reduces a time by 1 second
        /// </summary>
        public MyTime PreviousSecond()
        {
            try
            {
                Second -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Second = 59;
                PreviousMinute();
            }
            return this;
        }

        /// <summary>
        /// Reduces a time by 1 minute
        /// </summary>
        public MyTime PreviousMinute()
        {
            try
            {
                Minute -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Minute = 59;
                PrevioustHour();
            }
            return this;
        }

        /// <summary>
        /// Reduces a time by 1 hour
        /// </summary>
        public MyTime PrevioustHour()
        {
            try
            {
                Hour -= 1;
            }
            catch (ArgumentOutOfRangeException)
            {
                Hour = 23;
            }
            return this;
        }
    }
}