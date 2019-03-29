using System;
using System.Text;

namespace Day4Tasks
{
    /// <summary>
    /// The Polynomial class.
    /// Represents a polynomial of a real number
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Array of polynomial(a0*x^0 + ... + an*x^n) coefficients
        /// </summary>
        /// <example>_coefficients[0] is a0</example>
        /// <example>_coefficients[3] is a3</example>
        private double[] _coefficients;

        /// <summary>
        /// Initializes the polynomial coefficients
        /// </summary>
        /// <param name="coefficients">Polynomial coefficients</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when parameter coefficients is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when count of coefficients is less than one
        /// </exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(
                    "Parameter coefficients must be an array of doubles");
            }

            if (coefficients.Length < 1)
            {
                throw new ArgumentException("There must be at least one coefficient");
            }

            _coefficients = (double[])coefficients.Clone();
        }

        /// <summary>
        /// Get the degree of current polynomial
        /// </summary>
        public int Degree
        {
            get
            {
                return _coefficients.Length - 1;
            }
        }

        /// <summary>
        /// Index that provides read access to the coefficients
        /// </summary>
        /// <param name="degree">Degree</param>
        /// <returns>Coefficient</returns>
        public double this[int degree]
        {
            get
            {
                return _coefficients[degree];
            }
        }

        #region Operator+ overload

        /// <summary>
        /// The sum of two polynomials
        /// </summary>
        /// <param name="leftArg">Left polynomial</param>
        /// <param name="rightArg">Right polynomial</param>
        /// <returns>Polynomial that represent sum of two polynomials</returns>
        public static Polynomial operator +(Polynomial leftArg, Polynomial rightArg)
        {
            var degree = Math.Max(leftArg.Degree, rightArg.Degree);
            var coefficients = new double[degree + 1];
            leftArg.ToDoubleArray().CopyTo(coefficients, 0);

            for (var i = 0; i < rightArg.Degree + 1; i++)
            {
                coefficients[i] += rightArg[i];
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// The sum of polynomial and constant
        /// </summary>
        /// <param name="leftArg">Polynomial</param>
        /// <param name="constant">Constant</param>
        /// <returns>Polynomial that represent sum of polynomial and constant</returns>
        public static Polynomial operator +(Polynomial leftArg, double constant)
        {
            return leftArg + new Polynomial(constant);
        }

        /// <summary>
        /// The sum of polynomial and constant
        /// </summary>
        /// <param name="constant">Constant</param>
        /// <param name="rightArg">Polynomial</param>
        /// <returns>Polynomial that represent sum of polynomial and constant</returns>
        public static Polynomial operator +(double constant, Polynomial rightArg)
        {
            return rightArg + constant;
        }

        #endregion

        #region Binary operator- overload

        /// <summary>
        /// Subtracts the right polynomial from the left polynomial
        /// </summary>
        /// <param name="leftArg">Left polynomial</param>
        /// <param name="rightArg">Right polynomial</param>
        /// <returns>Difference between left and right polynomial</returns>
        public static Polynomial operator -(Polynomial leftArg, Polynomial rightArg)
        {
            return -rightArg + leftArg;
        }

        /// <summary>
        /// Subtracts the constant from the left polynomial
        /// </summary>
        /// <param name="leftArg">Polynomial</param>
        /// <param name="constant">Constant</param>
        /// <returns>Difference between left polynomial and right constant</returns>
        public static Polynomial operator -(Polynomial leftArg, double constant)
        {
            return leftArg - new Polynomial(constant);
        }

        /// <summary>
        /// Subtracts the polynomial from the constant
        /// </summary>
        /// <param name="constant">Constant</param>
        /// <param name="rightArg">Polynomial</param>
        /// <returns>Difference between left constant and right polynomial</returns>
        public static Polynomial operator -(double constant, Polynomial rightArg)
        {
            return new Polynomial(constant) - rightArg;
        }

        #endregion

        #region Unary operator- overload

        /// <summary>
        /// Change the polynomial sign
        /// </summary>
        /// <param name="polynomial">Polynomial</param>
        /// <returns>Polynomial whose coefficients are multiplied by -1</returns>
        public static Polynomial operator -(Polynomial polynomial)
        {
            return -1 * polynomial;
        }

        #endregion

        #region Operator* overload

        /// <summary>
        /// Multiplies polynomial by another polynomial
        /// </summary>
        /// <param name="leftArg">Left polynomial</param>
        /// <param name="rightArg">Right polynomial</param>
        /// <returns>Polynomial that multiplied by another polynomial</returns>
        public static Polynomial operator *(Polynomial leftArg, Polynomial rightArg)
        {
            var coefficients = new double[leftArg.Degree + rightArg.Degree + 1];

            for (var i = 0; i < leftArg.Degree + 1; i++)
            {
                for (var j = 0; j < rightArg.Degree + 1; j++)
                {
                    coefficients[i + j] += leftArg[i] * rightArg[j];
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Multiplies polynomial by constant
        /// </summary>
        /// <param name="polynomial">Polynomial</param>
        /// <param name="constant">Real constant</param>
        /// <returns>Polynomial that multiplied by constant</returns>
        public static Polynomial operator *(Polynomial polynomial, double constant)
        {
            return polynomial * new Polynomial(constant);
        }

        /// <summary>
        /// Multiplies polynomial by constant
        /// </summary>
        /// <param name="constant">Real constant</param>
        /// <param name="polynomial">Polynomial</param>
        /// <returns>Polynomial that multiplied by constant</returns>
        public static Polynomial operator *(double constant, Polynomial polynomial)
        {
            return polynomial * constant;
        }

        #endregion

        #region Comparison operators overload

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="leftArg">Left polynomial</param>
        /// <param name="rightArg">Right polynomial</param>
        /// <returns>Boolean value. True - equal, false - not equal</returns>
        public static bool operator ==(Polynomial leftArg, Polynomial rightArg)
        {
            if (leftArg.Degree != rightArg.Degree)
            {
                return false;
            }

            for (var i = 0; i < leftArg.Degree + 1; i++)
            {
                if (leftArg[i] != rightArg[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares polynomial and constant
        /// </summary>
        /// <param name="leftArg">Polynomial</param>
        /// <param name="constant">Constant</param>
        /// <returns>Boolean value. True - equal, false - not equal</returns>
        public static bool operator ==(Polynomial leftArg, double constant)
        {
            return leftArg == new Polynomial(constant);
        }

        /// <summary>
        /// Compares polynomial and constant
        /// </summary>
        /// <param name="constant">Constant</param>
        /// <param name="rightArg">Polynomial</param>
        /// <returns>Boolean value. True - equal, false - not equal</returns>
        public static bool operator ==(double constant, Polynomial rightArg)
        {
            return rightArg == constant;
        }

        /// <summary>
        /// Compares two polynomials
        /// </summary>
        /// <param name="leftArg">Left polynomial</param>
        /// <param name="rightArg">Right polynomial</param>
        /// <returns>Boolean value. True - not equal, false - equal</returns>
        public static bool operator !=(Polynomial leftArg, Polynomial rightArg)
        {
            return !(leftArg == rightArg);
        }

        /// <summary>
        /// Compares polynomial and constant
        /// </summary>
        /// <param name="leftArg">Polynomial</param>
        /// <param name="constant">Constant</param>
        /// <returns>Boolean value. True - not equal, false - equal</returns>
        public static bool operator !=(Polynomial leftArg, double constant)
        {
            return !(leftArg == constant);
        }

        /// <summary>
        /// Compares polynomial and constant
        /// </summary>
        /// <param name="constant">Constant</param>
        /// <param name="rightArg">Polynomial</param>
        /// <returns>Boolean value. True - not equal, false - equal</returns>
        public static bool operator !=(double constant, Polynomial rightArg)
        {
            return rightArg != constant;
        }

        #endregion

        /// <summary>
        /// Convert polynomial to an array of doubles
        /// </summary>
        /// <returns>Array of doubles that contains coefficients</returns>
        public double[] ToDoubleArray()
        {
            return (double[])_coefficients.Clone();
        }

        #region Object methods overrides

        public override bool Equals(object obj)
        {
            if (!(obj is Polynomial polynomial))
            {
                return false;
            }

            return this == polynomial;
        }

        public override int GetHashCode()
        {
            return _coefficients.GetHashCode();
        }

        public override string ToString()
        {
            var polynomialString = new StringBuilder();

            for (var i = 0; i < Degree + 1; i++)
            {
                var currentDegree = Degree - i;
                var coefficient = this[currentDegree];
                var variable = (currentDegree > 0) ? string.Format("x^{0}", currentDegree) : string.Empty;
                var sign = string.Empty;

                if (i > 0 && coefficient < 0)
                {
                    sign = " - ";
                    coefficient = -coefficient;
                }
                else if (i > 0)
                {
                    sign = " + ";
                }

                if (coefficient != 0)
                {
                    polynomialString.Append(string
                        .Format("{0}{1}{2}", sign, coefficient, variable));
                }
            }

            return polynomialString.ToString();
        }

        #endregion
    }
}
