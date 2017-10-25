﻿using System;
using System.Diagnostics;

namespace AlgebraLibrary
{
    /// <summary>
    /// Provides methods for computing the Greatest Common Divisor.</summary>
    /// <remarks>
    /// Applied to 2 or more numbers. 
    /// Uses conventional Euclidean and Stein's algotithms.</remarks>
    public class GreatestCommonDivisor
    {

        /// <summary>Computes GCD of 1 number.</summary>
        /// <param name="a"> A number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if "a" argument equals 0</returns>
        public static int EuclideanAlgorithm(int a)
        {
            return Math.Abs(a);
        }

        /// <summary>Computes GCD of 2 numbers.</summary>
        /// <param name="a"> The first number GCD is computing for.</param>
        /// <param name="b"> The second number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if both arguments equals 0</returns>
        public static int EuclideanAlgorithm(int a, int b)
        {
            return b != 0 ? EuclideanAlgorithm(b, a % b) : a != 0 ? Math.Abs(a) : 0;
        }

        /// <summary>Computes GCD of 3 numbers.</summary>
        /// <remarks>Uses EuclideanAlgorithm(int, int).</remarks>
        /// <param name="a"> The first number GCD is computing for.</param>
        /// <param name="b"> The second number GCD is computing for.</param>
        /// <param name="c"> The third number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if all arguments equals 0</returns>
        /// <seealso cref="EuclideanAlgorithm(int, int)"/>
        public static int EuclideanAlgorithm(int a, int b, int c)
        {
            return EuclideanAlgorithm(a, EuclideanAlgorithm(b, c));
        }

        /// <summary>Computes GCD of unlimited number of parameters.</summary>
        /// <remarks>Uses EuclideanAlgorithm() with one, two, three arguments.</remarks>
        /// <param name="numbers"> The range of numbers GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if all arguments equals 0</returns>
        /// <seealso cref="EuclideanAlgorithm(int, int)"/>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length <= 3)
            {
                return (numbers.Length == 3) ? EuclideanAlgorithm(numbers[0], numbers[1], numbers[2]) :
                                               (numbers.Length == 2) ? EuclideanAlgorithm(numbers[0], numbers[1]) :
                                                                       EuclideanAlgorithm(numbers[0]);
            }
            else
            {
                int[] left = new int[numbers.Length / 2];
                int[] right = new int[numbers.Length - (numbers.Length / 2)];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i < numbers.Length / 2)
                        left[i] = numbers[i];
                    else
                        right[i - numbers.Length / 2] = numbers[i];
                }

                int gcd_left = EuclideanAlgorithm(left);
                int gcd_right = EuclideanAlgorithm(right);

                return EuclideanAlgorithm(gcd_left, gcd_right);
            }
            
        }

        /// <summary>Computes GCD of 1 number.</summary>
        /// <param name="a"> A number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if "a" argument equals 0</returns>
        public static int SteinsAlgorothm(int a)
        {
            return Math.Abs(a);
        }

        /// <summary>Computes GCD of 2 numbers.</summary>
        /// <param name="a"> The first number GCD is computing for.</param>
        /// <param name="b"> The second number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if both arguments equals 0</returns>
        public static int SteinsAlgorithm(int a, int b)
        {
            if (a == 0)
                return Math.Abs(b);

            if (b == 0)
                return Math.Abs(a);

            if (a == b)
                return Math.Abs(a);
            
            if (a % 2 == 0)
            {
                if (b % 2 == 0)
                    return SteinsAlgorithm(a / 2, b / 2) * 2;
                else
                    return SteinsAlgorithm(a / 2, b);
            }

            if (b % 2 == 0)
                return SteinsAlgorithm(a, b / 2);
            
            if (a > b)
                return SteinsAlgorithm((a - b) / 2, b);

            return SteinsAlgorithm((b - a) / 2, a);
        }

        /// <summary>Computes GCD of 3 numbers.</summary>
        /// <remarks>Uses SteinsAlgorithm(int, int).</remarks>
        /// <param name="a"> The first number GCD is computing for.</param>
        /// <param name="b"> The second number GCD is computing for.</param>
        /// <param name="c"> The third number GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if all arguments equals 0</returns>
        /// <seealso cref="SteinsAlgorithm(int, int)"/>
        public static int SteinsAlgorithm(int a, int b, int c)
        {
            return SteinsAlgorithm(a, SteinsAlgorithm(b, c));
        }

        /// <summary>Computes GCD for unlimited number of parameters.</summary>
        /// <remarks>Uses SteinsAlgorithm() with one, two, three arguments.</remarks>
        /// <param name="numbers"> The range of numbers GCD is computing for.</param>
        /// <returns>Returns an absolute integer value of GCD 
        /// or 0 if all arguments equals 0</returns>
        /// <seealso cref="SteinsAlgorithm(int, int)"/>
        public static int SteinsAlgorithm(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length <= 3)
            {
                return (numbers.Length == 3) ? SteinsAlgorithm(numbers[0], numbers[1], numbers[2]) :
                                               (numbers.Length == 2) ? SteinsAlgorithm(numbers[0], numbers[1]) :
                                                                       SteinsAlgorithm(numbers[0]);
            }
            else
            {
                int[] left = new int[numbers.Length / 2];
                int[] right = new int[numbers.Length - (numbers.Length / 2)];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i < numbers.Length / 2)
                        left[i] = numbers[i];
                    else
                        right[i - numbers.Length / 2] = numbers[i];
                }

                int gcd_left = SteinsAlgorithm(left);
                int gcd_right = SteinsAlgorithm(right);

                return SteinsAlgorithm(gcd_left, gcd_right);
            }
            
        }

        public static int ComputeExecutionTime(out double time, params int[] numbers)
        {
            int max_rank = 1000000;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int gcd = EuclideanAlgorithm(numbers);

            sw.Stop();

            time = (double)(sw.Elapsed.TotalMilliseconds * max_rank) / max_rank;

            return gcd;
        }

    }
}
