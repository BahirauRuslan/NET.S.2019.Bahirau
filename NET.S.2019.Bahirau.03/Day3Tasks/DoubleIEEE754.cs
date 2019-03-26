using System;
using System.Text;

namespace Day3Tasks
{
    /// <summary>
    /// The DoubleIEEE754 static class.
    /// Contains methods for representing the double to IEEE 754 format
    /// </summary>
    public static class DoubleIEEE754
    {
        /// <summary>
        /// Returns the binary string representation of a double in the IEEE 754 format
        /// </summary>
        /// <param name="number">Double number</param>
        /// <returns>String representation of a double in the IEEE 754 format</returns>
        public static string ToIEEE754String(this double number)
        {
            string specialCase = ToIEEE754SpecialCase(number);

            if (specialCase != string.Empty)
            {
                return specialCase;
            }

            string sign = GetIEEE754Sign(number);
            string exponentIEEE754 = GetIEEE754Exponent(number);
            string mantissa = GetIEEE754Mantissa(number, GetExponent(number));
            return string.Format("{0}{1}{2}", sign, exponentIEEE754, mantissa);
        }

        /// <summary>
        /// Returns sign of double
        /// </summary>
        /// <param name="number">Double number</param>
        /// <returns>String binary sign of double</returns>
        private static string GetIEEE754Sign(double number)
        {
            return (number < 0.0 || 1.0 / number < 0.0) ? "1" : "0";
        }

        /// <summary>
        /// Returns the mantissa of double
        /// </summary>
        /// <param name="number">Double number</param>
        /// <param name="exponent">Integer exponent of number</param>
        /// <returns>String representation of mantissa in IEEE 754 format</returns>
        private static string GetIEEE754Mantissa(double number, int exponent)
        {
            if (number == 0)
            {
                return string.Empty.PadRight(52, '0');
            }

            StringBuilder mantissa = new StringBuilder();
            number = Math.Abs(number);
            number /= Math.Pow(2, exponent - 1023);
            number--;

            while (number != 0)
            {
                number *= 2;
                if (number >= 1)
                {
                    mantissa.Append("1");
                    number--;
                }
                else
                {
                    mantissa.Append("0");
                }
            }
            
            return mantissa.ToString().PadRight(52, '0');
        }

        /// <summary>
        /// Returns string representation of number exponent in IEEE 754 format
        /// </summary>
        /// <param name="number">Double number</param>
        /// <returns>String representation of number exponent</returns>
        private static string GetIEEE754Exponent(double number)
        {
            int exponent = GetExponent(number);
            StringBuilder exponentIEEE754 = new StringBuilder();

            while (exponent != 0)
            {
                exponentIEEE754.Insert(0, exponent % 2);
                exponent /= 2;
            }

            return exponentIEEE754.ToString().PadLeft(11, '0');
        }

        /// <summary>
        /// Returns the binary string representation of a special case double in the IEEE 754 format
        /// </summary>
        /// <param name="number">Double special number</param>
        /// <returns>
        /// Binary string representation of a special case double in the IEEE 754 format 
        /// or empty string
        /// </returns>
        private static string ToIEEE754SpecialCase(double number)
        {
            if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.MaxValue)
            {
                return "0111111111101111111111111111111111111111111111111111111111111111";
            }

            if (number == double.MinValue)
            {
                return "1111111111101111111111111111111111111111111111111111111111111111";
            }

            if (number == double.Epsilon)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns exponent of double
        /// </summary>
        /// <param name="number">Double number</param>
        /// <returns>Integer exponent of double</returns>
        private static int GetExponent(double number)
        {
            number = Math.Abs(number);
            return (number != 0) ? 1023 + (int)Math.Floor(Math.Log(number, 2)) : 0;
        }
    }
}
