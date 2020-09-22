using System;

namespace Task_3._3C
{
    class MyPolynomial
    {
        // Instance variables
        private double[] _coeffs;

        /// <summary>
        /// Constructor for a polynomial
        /// </summary>
        /// <param name="coeffs">Double array of coefficients</summary>
        public MyPolynomial(double[] coeffs)
        {
            _coeffs = coeffs;
        }

        /// <summary>
        /// Returns the degree of the polynomial
        /// </summary>
        /// <returns>
        /// The degree of the polynomial as an integer
        /// </returns>
        public int GetDegree()
        {
            return _coeffs.Length - 1;
        }

        /// <summary>
        /// Returns a common string representation of a polynomial
        /// </summary>
        /// <returns>
        /// String representation of an expanded polynomial
        /// </returns>
        public override String ToString()
        {
            String result = "";
            String op, exp;
            double num;
            for (int i = _coeffs.Length - 1; i >= 0; i--)
            {
                num = _coeffs[i];
                // If num is less than 0, add " - " to the string, otherwise
                // add " + " as long as this isn't the start of the string
                // Example:
                // - 4x^2 + 2x - 2 (print minus sign at start)
                // 4x^2 + 2x - 2 (don't print plus sign at start)
                op = num < 0 ? "- " : (i < _coeffs.Length - 1 && num > 0) ? "+ " : "";
                num = Math.Abs(num);
                exp = (i == 0 && num != 0) ? num.ToString()             // If constant and not 0, then concatenate to string
                    : (i == 1 && num == 1) ? "x "                       // if 1x^1, don't print 1 or ^1, just x
                    : (i == 1 && num != 0) ? num.ToString() + "x "      // if ax^1, don't print ^1, just ax (a not 0)
                    : (i > 1 && num == 1) ? $"x^{i} "                   // don't print 1 before any number, but include coefficient if > 1
                    : (i > 1 && num != 0) ? num.ToString() + $"x^{i} "  // otherwise if not 0, print ax^coeff
                    : "";                                               // if 0, add nothing to the string
                result += (op + exp);                                   // add the operator and the exponent part
            }
            return result;
        }

        /// <summary>
        /// Calculates the value of f(x) for a given value of x
        /// </summary>
        /// <returns>
        /// Double value of substituting x into the polynomial
        /// </returns>
        public double Evaluate(double x)
        {
            double result = _coeffs[0];
            for (int i = 1; i < _coeffs.Length; i++)
            {
                result += _coeffs[i] * Math.Pow(x, i);
            }
            return result;
        }

        /// <summary>
        /// Returns the value of the coefficent at the given index position
        /// </summary>
        /// <returns>
        /// Double value of the coefficient at the given index
        /// </returns>
        /// <exception cref="System.IndexOutOfRangeException">Thrown when index
        /// is larger than the size of the coefficients array</exception>
        public double CoeffAt(int index)
        {
            try
            {
                return _coeffs[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(
                        "Index " + index
                        + " not valid for a polynomial of length "
                        + _coeffs.Length);
            }
        }

        /// <summary>
        /// Adds another polynomial to this
        /// </summary>
        /// <returns>
        /// this polynomial
        /// </returns>
        /// <param name="other">The polynomial to add</param>
        public MyPolynomial Add(MyPolynomial other)
        {
            double[] result;
            bool longer = this.GetDegree() >= other.GetDegree();
            if (longer)
                result = new double[_coeffs.Length];
            else
                result = new double[other.GetDegree() + 1];
            for (int i = 0; i < result.Length; i++)
            {
                try
                {
                    result[i] = _coeffs[i] += other.CoeffAt(i);
                }
                catch (IndexOutOfRangeException)
                {
                    if (longer)
                        result[i] = _coeffs[i];
                    else
                        result[i] = other.CoeffAt(i);
                }
            }
            _coeffs = result;
            return this;
        }

        /// <summary>
        /// Multiplies this by another polynomial
        /// </summary>
        /// <returns>
        /// this polynomial
        /// </returns>
        /// <param name="other">The polynomial to multiply by</param>
        public MyPolynomial Multiply(MyPolynomial other)
        {
            double[] product = new double[_coeffs.Length + other.GetDegree()];
            for (int i = 0; i < _coeffs.Length; i++)
            {
                for (int j = 0; j < other.GetDegree() + 1; j++)
                {
                    product[i + j] += _coeffs[i] * other.CoeffAt(j);
                }
            }
            _coeffs = product;
            return this;
        }
    }
}
