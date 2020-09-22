using System;

namespace Task_3._3C
{
    class TestMyPolynomial
    {
        public static String CoeffsToString(MyPolynomial poly)
        {
            String result = "[";
            for (int i = 0; i < poly.GetDegree(); i++)
            {
                result += poly.CoeffAt(i) + ", ";
            }
            result += poly.CoeffAt(poly.GetDegree()) + "]:  ";
            return result;
        }

        public static MyPolynomial RandomPolynomial(Random rnd, int min, int max)
        {
            double[] coeffs = new double[rnd.Next(1, max)];
            int num = 0;
            for (int j = 0; j < coeffs.Length; j++)
            {
                num = rnd.Next(min, max);
                if (num % 7 == 0)
                    num = 0;
                coeffs[j] = Convert.ToDouble(num);
            }
            if (coeffs[coeffs.Length - 1] == 0)
                coeffs[coeffs.Length - 1] = 7;
            return new MyPolynomial(coeffs);
        }
        public static void Main(string[] args)
        {
            int numberOfTests = 50;

            // Test ToString by creating 100 random sets of arrays and
            // creating polynomials for each one and printing via
            // ToString
            Console.WriteLine("\n\nTesting ToString:\n");
            Random rnd = new Random();

            for (int i = 0; i < numberOfTests; i++)
            {
                MyPolynomial poly = RandomPolynomial(rnd, -20, 20);
                Console.WriteLine("\n" + CoeffsToString(poly));
                Console.WriteLine(poly.ToString());
            }

            // Test evaluate
            Console.WriteLine("\n\nTesting evaluating a polynomial");

            for (int i = 0; i < numberOfTests; i++)
            {

                double x = rnd.Next(-10, 10);
                MyPolynomial poly2 = RandomPolynomial(rnd, -10, 10);
                double result = poly2.Evaluate(x);
                Console.WriteLine("\n({0}), {1} = {2}", poly2.ToString(), x, result);
            }

            // Test adding polynomials
            Console.WriteLine("\n\nTesting adding polynomials:\n");

            for (int i = 0; i < numberOfTests; i++)
            {
                MyPolynomial poly5 = RandomPolynomial(rnd, -5, 5);
                MyPolynomial poly6 = RandomPolynomial(rnd, -5, 5);
                Console.Write("\n({0}) + ({1}) = ", poly5.ToString(), poly6.ToString());
                poly5.Add(poly6);
                Console.WriteLine(poly5.ToString());
            }

            // Test multiplying polynomials
            Console.WriteLine("\n\nTesting multiplying polynomials:\n");

            for (int i = 0; i < numberOfTests; i++)
            {
                MyPolynomial poly5 = RandomPolynomial(rnd, -5, 5);
                MyPolynomial poly6 = RandomPolynomial(rnd, -5, 5);
                Console.Write("\n({0}) x ({1}) = ", poly5.ToString(), poly6.ToString());
                poly5.Multiply(poly6);
                Console.WriteLine(poly5.ToString());
            }
        }
    }
}