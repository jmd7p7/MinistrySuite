using System;

namespace MinistrySuite.Util
{
    //The idea for this Guard class and some of the methods came from 
    //Pluralsight's Domain Driven Design Fundamentals by Julie Lerman 
    //And Steve Smith
    public static class Guard
    {
        //This method came from the tutorial with a bit of tweaking
        public static void ForLessEqualZero(int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} cannot be less than or equal to zero.");
            }
        }

        //This method came from the tutorial with a bit of tweaking
        public static void ForNullOrEmptyOrWhiteSpace(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{parameterName} cannot be null, empty, or whitespace.");
            }
        }

        public static void ForOutSideMinOrMaxIntegerBounds(int min, int max, int value, string parameterName)
        {
            if (value < min)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is less than minimum integer bound.");
            }
            if (value > max)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is greater than maximum integer bound.");
            }
        }

        public static void ForOutSideMinOrMaxDateTimeBounds(DateTime minDate, DateTime maxDate, DateTime value, string parameterName)
        {
            if (value < minDate)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is less than minimum DateTime bound.");
            }

            if (value > maxDate)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is greater than maximum DateTime bound.");
            }
        }

        public static void ForOutSideMinOrMaxDateTimeOffSetBounds(DateTimeOffset minDate, DateTimeOffset maxDate, DateTimeOffset value, string parameterName)
        {
            if (value < minDate)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is less than minimum DateTime bound.");
            }

            if (value > maxDate)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} is greater than maximum DateTime bound.");
            }
        }

        public static void ForNull(object obj, string parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException($"{parameterName} cannot be null.");
            }
        }
    }
}
