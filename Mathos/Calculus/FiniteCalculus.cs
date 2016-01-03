using System;
using System.Globalization;
using Mathos.Arithmetic.Numbers;
using Mathos.Notation;

namespace Mathos.Calculus
{
    /// <summary>
    /// This class contains methods for calculus with finite differences. Most of the methods assume that the sequence of
    /// numbers is some sort of polynomial.
    /// </summary>
    public static class FiniteCalculus
    {
        /// <summary>
        /// This method will evaluate a sum that contains a true-false statement - the Iverson notation.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="rule"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static double SumWithRule(Func<double, double> function, Func<double, bool> rule, int min, int max)
        {
            double result = 0;

            for (var i = min; i < max; i++)
            {
                if (rule(i))
                    result += function(i);
            }

            return result;
        }

        /// <summary>
        ///     Finds an expression, given coefficients of the nth sum, in terms of any variable.
        /// </summary>
        /// <param name="coeff">The coefficients for the nth sum. You can obtain them with GetCoefficientsForNthSum.</param>
        /// <returns></returns>
        public static string GetExpressionForNthSum(double[] coeff)
        {
            return GetExpressionForNthTerm(coeff);
        }

        /// <summary>
        /// Finds the coefficients of the closed form of the sum and returns them in a double array. The first item in the
        /// array is of the highest power. The last term in the array is the constant term.
        /// </summary>
        /// <param name="sequence">The sequence of doubles passed in as a double array.</param>
        /// <param name="degree">
        /// The degree value returned here is the number of times we have to take the differnce of this
        /// sequence (using GetDifference) to get the difference to be zero.
        /// </param>
        /// <returns></returns>
        public static double[] GetCoefficientsForNthSum(double[] sequence, int degree)
        {
            var partialSums = new double[sequence.Length];

            partialSums[0] = sequence[0];

            for (var i = 1; i < sequence.Length; i++)
                partialSums[i] = partialSums[i - 1] + sequence[i];

            return GetCoefficientsForNthTerm(partialSums, degree + 1);
        }

        /// <summary>
        /// Finds an expression, given coefficients of the nth term, in terms of any variable.
        /// </summary>
        /// <param name="coeff">The coefficients for the nth term. You can obtain them with GetCoefficientsForNthTerm.</param>
        /// <param name="variable">The variable we should you when expressing the nth term.</param>
        /// <param name="round">The number of digits we should round to in the fractional part of the number.</param>
        /// <returns></returns>
        public static string GetExpressionForNthTerm(double[] coeff, char variable = 'x', int round = 10)
        {
            var expr = "";

            for (var i = 0; i < coeff.Length; i++)
            {
                coeff[i] = Math.Round(coeff[i], round);

                if (Math.Abs(coeff[i]) > 0 && i < coeff.Length - 1)
                {
                    if (Math.Abs(coeff[i] - 1) > 1 || Math.Abs(coeff[i] - 1) < 1)
                        expr += (coeff[i]).ToString(CultureInfo.InvariantCulture) + variable;
                    else
                        expr += variable;

                    if (i < coeff.Length - 2)
                        expr += "^" + (coeff.Length - i - 1);
                }
                else
                {
                    if (Math.Abs(coeff[i]) > 0)
                        expr += (coeff[i]).ToString(CultureInfo.InvariantCulture);
                }

                if (i >= coeff.Length - 1)
                    continue;

                coeff[i + 1] = Math.Round(coeff[i + 1], round);

                if (coeff[i + 1] > 0)
                    expr += "+";
            }

            return expr;
        }

        /// <summary>
        /// Finds the coefficients of the nth term and returns them in a double array. The first item in the array is of the
        /// highest power. The last term in the array is the constant term.
        /// </summary>
        /// <param name="sequence">The sequence of doubles passed in as a double array.</param>
        /// <param name="degree">
        /// The degree value returned here is the number of times we have to take the differnce of this
        /// sequence (using GetDifference) to get the difference to be zero.
        /// </param>
        /// <returns></returns>
        public static double[] GetCoefficientsForNthTerm(double[] sequence, int degree)
        {
            var mat = new Matrix(degree, degree + 1);

            for (var i = 0; i < degree; i++)
            {
                for (var j = 0; j <= degree; j++)
                    mat[i, j] = j == degree ? sequence[i] : Get.IntPower(i + 1, (short) (degree - j - 1));
            }

            mat.RREF();

            var output = new double[degree];

            for (var i = 0; i < degree; i++)
                output[i] = mat[i, degree];

            return output;
        }

        /// <summary>
        /// Finds the difference between terms in a sequence. By chaging the degree, we can take difference of the differences.
        /// </summary>
        /// <param name="sequence">The sequence of doubles passed in as a double array.</param>
        /// <param name="term">
        /// The index of the first term where the diff. should be taken. NB: As the degree increases, the
        /// smaller can the term be
        /// </param>
        /// <param name="degree">
        /// The type of difference, i.e. if degree=1, the first difference is taken and if degree=2, the
        /// difference of the first difference is taken.
        /// </param>
        /// <example>If the sequence is {1,2,3,4,...}, term=0, degree=1, we get 1. By changning degree=2, we get 0.</example>
        /// <returns>The difference between the terms in the sequence, depending on the degree.</returns>
        public static double GetDifference(double[] sequence, int term, int degree)
        {
            // the pascal's triangle should be optimized. we only need half of the values
            double result = 0;

            var evenStart = (term + degree)%2 == 0;
            var j = 0;

            for (var i = term + degree; j <= degree; i--)
            {
                result += Pascal(degree, j)*sequence[i]*(evenStart ? (i%2 == 0 ? 1 : -1) : (i%2 == 0 ? -1 : 1));
                j++;
            }

            return result;
        }


        /// <summary>
        /// Finds the next term in the sequence, given that a pattern exist.
        /// </summary>
        /// <param name="sequence">The sequence of doubles passed in as a double array.</param>
        /// <param name="term">
        /// If term=-1, the next term in the sequence is going to be found. By default, you don't need to change
        /// this variable.
        /// </param>
        /// <returns></returns>
        public static double GetNextTerm(double[] sequence, int term = -1)
        {
            int constantIndex;

            if (!HasPattern(sequence, out constantIndex))
                throw new Exception("The sequence does not contain a recognized pattern.");

            var constant = GetDifference(sequence, 0, constantIndex - 1);

            if (term == -1)
            {
                // have find the term to start with to figure out the n+1 term.
                term = sequence.Length - constantIndex;
            }

            double result = 0;

            var evenStart = (term + constantIndex - 1)%2 == 0;
            var j = 1;

            result += constant;

            for (var i = term + constantIndex - 1; j <= constantIndex - 1; i--)
            {
                result += Pascal(constantIndex - 1, j)*sequence[i]*
                          (evenStart ? (i%2 == 0 ? 1 : -1) : (i%2 == 0 ? -1 : 1));
                j++;
            }

            return result;
        }

        /// <summary>
        /// Checks whether the given sequence contains a pattern. For a pattern to exist, given the terms in the sequence, we
        /// should be able to reach a difference of zero for all possible values of degree. Degree is dependent on the number
        /// of terms we have.
        /// </summary>
        /// <param name="sequence">The sequence of doubles passed in as a double array.</param>
        /// <param name="degree">
        /// The degree value returned here is the number of times we have to take the differnce of this
        /// sequence (using GetDifference) to get the difference to be zero.
        /// </param>
        /// <param name="checkAllTerms">
        /// By default, we only check if we can get any kind of difference (of different degrees) to be
        /// zero for the smallest term. If this option is true, all terms are going to be checked to follow the pattern.
        /// </param>
        /// <returns></returns>
        public static bool HasPattern(double[] sequence, out int degree, bool checkAllTerms = false)
        {
            for (var i = 1; i < sequence.Length; i++)
            {
                if (Math.Abs(GetDifference(sequence, 0, i)) > 0)
                    continue;

                if (checkAllTerms)
                {
                    for (var j = 1; j*i <= sequence.Length; j++)
                    {
                        if (Math.Abs(GetDifference(sequence, j, i)) < 1)
                            continue;

                        degree = 0;

                        return false;
                    }
                }

                degree = i;

                return true;
            }

            degree = 0;

            return false;
        }
        
        private static double Pascal(int x, int y)
        {
            return (x + 1) == 1 || (y + 1) == 1 || (x == y) ? 1 : Pascal(x - 1, y - 1) + Pascal(x - 1, y);
        }
    }
}
