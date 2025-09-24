using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Practices.Problems
{
    public class FractionToRecurringDecimal
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return "0";
            }

            StringBuilder fraction = new StringBuilder();

            // Negative Check
            if (numerator < 0 ^ denominator < 0)
            {
                fraction.Append('-');
            }

            long upper = Math.Abs((long)numerator);
            long lower = Math.Abs((long)denominator);

            long quotient = (long)(upper / lower);
            long remainder = (long)(upper % lower);

            fraction.Append(quotient);

            // Check if the reminder is Zero
            if (remainder == 0)
            {
                return fraction.ToString();
            }

            fraction.Append('.');

            Dictionary<long, int> repeatDigits = new();
            while (remainder != 0)
            {
                if (repeatDigits.TryGetValue(remainder, out int value))
                {
                    fraction.Insert(value, '(');
                    fraction.Append(')');
                    break;
                }
                repeatDigits.Add(remainder, fraction.Length);
                remainder *= 10;
                fraction.Append(remainder / lower);
                remainder %= lower;
            }

            return fraction.ToString();
        }
    }
}
