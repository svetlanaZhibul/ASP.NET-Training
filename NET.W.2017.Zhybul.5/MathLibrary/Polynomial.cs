using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    /// <summary>
    /// Immutable class.
    /// Provides methods for standart operations with polynomials.</summary>
    /// <remarks>
    /// Polynomial can be calculated in a particular point.</remarks>
    public class Polynomial
    {
        private int degree;
        private double[] coefficients;

        public Polynomial()
        {
            degree = 0;
            coefficients = new double[1] { 1 };
        }
        public Polynomial(int degree, double[] coefficients)
        {
            if (coefficients.Length != degree + 1 || degree < 0 || coefficients == null)
            {
                throw new ArgumentException();
                //this.degree = 0;
                //this.coefficients = new double[1] { 1 };
            }
            else
            {
                this.degree = degree;
                this.coefficients = coefficients;
            }
        }
        int Degree
        {
            get
            {
                return degree;
            }
            //set
            //{
            //    degree = value;
            //}
        }
        double[] Coefficients
        {
            get
            {
                return coefficients;
            }
            //set
            //{
            //    coefficients = value;
            //}
        }

        /// <summary>Computes sum of two polynomials.</summary>
        /// <param name="p1"> First variable of Polynomial type.</param>
        /// <param name="p2"> Second variable of Polynomial type.</param>
        /// <returns>New polynomial made of p1 and p2 sum</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            //if (p1 == null || p2 == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //if (p1.degree < 0 || p2.degree < 0)
            //{
            //    throw new ArgumentException();
            //}

            //if (p1.coefficients == null || p2.coefficients == null)
            //{
            //    throw new ArgumentException();
            //}

            int degree = Math.Max(p1.degree, p2.degree);
            int minDegree = Math.Min(p1.degree, p2.degree);

            double[] coefficients = new double[degree + 1];

            for (int i = 0; i <= minDegree; i++)
            {
                coefficients[i] = p1.Coefficients[i] + p2.Coefficients[i];
            }

            for (int i = minDegree + 1; i <= degree; i++)
            {
                if (p1.Coefficients.Length == degree)
                {
                    coefficients[i] = p1.Coefficients[i];
                }
                else
                {
                    coefficients[i] = p2.Coefficients[i];
                }
            }

            double[] reserveCoefficients = null;
            while (coefficients[degree] == 0 && degree != 0)
            {
                degree--;
                reserveCoefficients = new double[degree + 1];
                for (int i = 0; i <= degree; i++)
                {
                    reserveCoefficients[i] = coefficients[i];
                }
            }

            Polynomial result;
            if (reserveCoefficients != null)
                result = new Polynomial(degree, reserveCoefficients);
            else
                result = new Polynomial(degree, coefficients);

            return result;
        }

        /// <summary>Computes difference of two polynomials.</summary>
        /// <param name="p1"> First variable of Polynomial type.</param>
        /// <param name="p2"> Second variable of Polynomial type.</param>
        /// <returns>New polynomial made of p1 and p2 difference</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            //if (p1 == null || p2 == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //if (p1.degree < 0 || p2.degree < 0)
            //{
            //    throw new ArgumentException();
            //}

            //if (p1.coefficients == null || p2.coefficients == null)
            //{
            //    throw new ArgumentException();
            //}

            int degree = Math.Max(p1.degree, p2.degree);
            int minDegree = Math.Min(p1.degree, p2.degree);

            double[] coefficients = new double[degree + 1];

            for (int i = 0; i <= minDegree; i++)
            {
                coefficients[i] = p1.Coefficients[i] - p2.Coefficients[i];
            }

            for (int i = minDegree + 1; i <= degree; i++)
            {
                if (p1.Coefficients.Length == degree)
                {
                    coefficients[i] = p1.Coefficients[i];
                }
                else
                {
                    coefficients[i] = -p2.Coefficients[i];
                }
            }

            double[] reserveCoefficients = null;
            while (coefficients[degree] == 0 && degree != 0)
            {
                degree--;
                reserveCoefficients = new double[degree + 1];
                for (int i = 0; i <= degree; i++)
                {
                    reserveCoefficients[i] = coefficients[i];
                }
            }

            Polynomial result;
            if (reserveCoefficients != null)
                result = new Polynomial(degree, reserveCoefficients);
            else
                result = new Polynomial(degree, coefficients);

            return result;
        }


        public static Polynomial operator *(Polynomial p1, double number)
        {
            //if (p1 == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //if (p1.degree < 0 || p1.coefficients == null)
            //{
            //    throw new ArgumentException();
            //}

            Polynomial p;

            if (number == 0)
            {
                p = new Polynomial(0, new double[1] { 0 });
            }
            else
            {
                p = new Polynomial(p1.degree, new double[p1.degree + 1]);

                for (int i = 0; i <= p1.degree; i++)
                {
                    p.coefficients[i] = p1.Coefficients[i] * number;
                }
            }
            
            return p;
        }

        /// <summary>Computes product of two polynomials.</summary>
        /// <param name="p1"> First variable of Polynomial type.</param>
        /// <param name="p2"> Second variable of Polynomial type.</param>
        /// <returns>New polynomial made of p1 and p2 product</returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            //if (p1 == null || p2 == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //if (p1.degree < 0 || p2.degree < 0)
            //{
            //    throw new ArgumentException();
            //}

            //if (p1.coefficients == null || p2.coefficients == null)
            //{
            //    throw new ArgumentException();
            //}

            int degree = p1.degree + p2.degree;
            Polynomial p;
            double[] coef = new double[degree + 1];
            for (int i = 0; i <= degree; i++)
            {
                coef[i] = 0;
            }
            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    coef[i + j] += p1.Coefficients[i] * p2.Coefficients[j];
                }
            }

            p = new Polynomial(degree, coef);

            return p;
        }

        /// <summary>Verifies if two polynomials are equal.</summary>
        /// <param name="p1"> First variable of Polynomial type.</param>
        /// <param name="p2"> Second variable of Polynomial type.</param>
        /// <returns>Returns result due to equality between two instances</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)// check if this is neccessary due to nullRefException, will the call occure or fall
            {
                throw new ArgumentNullException();
            }

            if (p1.Degree < 0 || p2.Degree < 0)
            {
                throw new ArgumentException();
            }

            if (p1.Degree != p2.Degree)
            {
                return false;
            }
            else
            {
                for (int i = 0; i <= p1.Degree; i++)
                {
                    if (p1.Coefficients[i] != p2.Coefficients[i])
                        return false;
                }
            }

            return true;
        }

        /// <summary>Verifies if two polynomials are not equal.</summary>
        /// <param name="p1"> First variable of Polynomial type.</param>
        /// <param name="p2"> Second variable of Polynomial type.</param>
        /// <returns>Returns result due to equality between two instances</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                // is this neccessary due to nullRefException, will the call occure or fall?
            {
                throw new ArgumentNullException();
            }

            if (p1.Degree < 0 || p2.Degree < 0)
            {
                throw new ArgumentException();
            }

            if (p1.Degree != p2.Degree)
            {
                return true;
            }
            else
            {
                for (int i = 0; i <= p1.Degree; i++)
                {
                    if (p1.Coefficients[i] != p2.Coefficients[i])
                        return true;
                }
            }

            return false;
        }

        /// <summary>Calculates the polynomial in a particular point.</summary>
        /// <param name="point"> Real number value polynomial is calculated at.</param>
        /// <returns>Returns value of current instance at point </returns>
        public double ComputeAtPoint (double point)
        {
            // checking ??? null / degree with "-" ....
            double result = 0.0;
            for (int i = 0; i <= Degree; i++)
            {
                result += Coefficients[i] * Math.Pow(point, i);
            }
            return result;
        }

        /// <summary>Verifies if two objects of polynomial type are equal.</summary>
        /// <param name="p"> First variable of Polynomial type.</param>
        /// <param name="q"> Second variable of Polynomial type.</param>
        /// <returns>Returns result due to equality between two instances</returns>
        public static bool Equals(Polynomial p, Polynomial q)
        {
            if (p == null || q == null)
            {
                throw new ArgumentNullException();
            }
            return q == p;
        }
        /// <summary>Verifies if object and current Polynomial variable are equal.</summary>
        /// <param name="other"> Object current Polynomial variable is compared to.</param>
        /// <returns>Returns result due to equality between current instance and given object</returns>
        public override bool Equals(object other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
                // return false;
            }
            if (other.GetType() == this.GetType())
            {
                Polynomial polynomial = (Polynomial)other;
                if (this == polynomial)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        /// <summary>Computes hash value for current object of Polynomial type.</summary>
        /// <returns>Returns value of hash code of an instance.</returns>
        public override int GetHashCode()
        {
            //???
            return Coefficients.GetHashCode() + Degree;
        }
        
    }
}
