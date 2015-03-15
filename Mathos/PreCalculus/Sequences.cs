using System;

namespace Mathos.PreCalculus.Sequences
{
    /// <summary>
    /// 
    /// </summary>
    public class ArithmeticProgression
    {
        private double _initialTerm;
        private double _commonDifference;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArithmeticProgression() : this(0, 0)
        {
        }

        /// <summary>
        /// Constructor with an "initialterm" and a "commondifference"
        /// </summary>
        /// <param name="initialterm"></param>
        /// <param name="commondifference"></param>
        public ArithmeticProgression(double initialterm, double commondifference)
        {
            _initialTerm = initialterm;
            _commonDifference = commondifference;
        }

        /// <summary>
        /// Gets or sets the the "_initialTerm"
        /// </summary>
        public double InitialTerm
        {
            get { return _initialTerm; }
            set { _initialTerm = value; }
        }

        /// <summary>
        /// Gets or sets the the "_commonDifference"
        /// </summary>
        public double CommonDifference
        {
            get { return _commonDifference; }
            set { _commonDifference = value; }
        }

        /// <summary>
        /// Gets N-th term of Arithmetic Progression
        /// </summary>
        public double NTerm(Int32 n)
        {
            return _initialTerm + (n - 1) * _commonDifference;
        }

        /// <summary>
        /// Gets Sum of n-members (Seria)
        /// </summary>
        public double Sum(Int32 n)
        {
            var tmpLeft = ((double) n/2);

            return tmpLeft * (2 * _initialTerm + (n - 1) * _commonDifference);
        }

    }
     
    /// <summary>
    /// Geometric Progression
    /// </summary>
    public class GeometricProgression
    {
        private double _initialTerm;
        private double _commonRatio;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GeometricProgression() : this(1, 1)
        {
        }

        /// <summary>
        /// Constructor with an "initialterm" and a "commonratio"
        /// </summary>
        /// <param name="initialterm"></param>
        /// <param name="commonratio"></param>
        /// <exception cref="ArgumentException"></exception>
        public GeometricProgression(double initialterm, double commonratio)
        {
            if (Math.Abs(initialterm) > 0 & Math.Abs(commonratio) > 0)
            {
                _initialTerm = initialterm;
                _commonRatio = commonratio;
            }
            else
                throw new ArgumentException("Initial Term or Common Ratio can not be 0");
        }

        /// <summary>
        /// Gets or sets the the "_initialTerm" and Common Difference
        /// </summary>
        public double InitialTerm
        {
            get { return _initialTerm; }
            set { _initialTerm = value; }
        }

        /// <summary>
        /// Gets or sets the the "_commonRatio"
        /// </summary>
        public double CommonRatio
        {
            get { return _commonRatio; }
            set { _commonRatio = value; }
        }

        /// <summary>
        /// Gets N-th term of Geometric Progression
        /// </summary>
        public double NTerm(Int32 n)
        {
            return _initialTerm * (Math.Pow(_commonRatio, n));
        }

        /// <summary>
        /// Gets Sum of n-members (n-Seria)
        /// </summary>
        public double Sum(Int32 n)
        {
            return _initialTerm * (1 - Math.Pow(_commonRatio, n + 1)) / (1 - _commonRatio);
        }

        /// <summary>
        /// Gets Infinite Sum 
        /// </summary>
        public double InfiniteSum()
        {
            if ((Math.Abs(_commonRatio)) < 1)
                return _initialTerm / (1 - _commonRatio);
            
            throw new ArgumentException("Absolute value of Common Ratio must be less 1");
        }
    }
    /// <summary>
    /// Fibonacci numbers
    /// Enclidean algorithm (greatest common divisor)
    /// In nature: Botany, DNA, The bee ancestry code
    /// 
    /// NOTE: This class contains both static and non-static functions. You have to declare a new object of the Fibonacci class in order to access the non-static memebers. 
    /// </summary>
    public class Fibonacci
    {
        private int _initialTerm;
        private int _firstTerm = 1;

        /// <summary>
        /// Gets or sets the the "_initialTerm"
        /// </summary>
        public int InitialTerm
        {
            get { return _initialTerm; }
            set { _initialTerm = value; }
        }

        /// <summary>
        /// Gets or sets the the "_firstTerm"
        /// </summary>
        public int FirstTerm
        {
            get { return _firstTerm; }
            set { _firstTerm = value; }
        }

        /// <summary>
        /// Gets N-th Fibonacci number
        /// </summary>
        public int NTerm(Int32 n)
        {
            var fk = 0;

            if (n == 0) return _initialTerm;
            if (n == 1) return _firstTerm;
            if (n <= 1) return 0;
            
            //Fk = Fk_1 + Fk_2 & k>=2
            var k = 2;
            var fk2 = _initialTerm;
            var fk1 = _firstTerm;
           
            while (k <= n)
            {
                fk = fk1 + fk2;
                fk2 = fk1;
                fk1 = fk;
                k++; 
            }

            return fk;
        }
        
        /// <summary>
        /// Binet's Formula, Gets N-th Fibonacci number
        /// </summary>
        public static double BinetFormula(Int32 n)
        {
          return
          (Math.Pow((1 + Math.Sqrt(5)) / 2, n) - Math.Pow((1 - Math.Sqrt(5)) / 2, n)) / Math.Sqrt(5); 
        }

        /// <summary>
        /// Golden Ratio
        /// </summary>
        public static double GoldenRatio()
        {
          return (1 + Math.Sqrt(5)) / 2; 
        }

        /// <summary>
        /// If we know F is a Fibonacci number we can find its index
        /// </summary>
        /// 
        public int Index(int f)
        {
            var phi = GoldenRatio();
            var n = Math.Log((f*Math.Sqrt(5) + 0.5), phi);
            
            return Convert.ToInt32( Math.Round(n));
        }


        //Fibonacci code snippet: http://stackoverflow.com/questions/4357223/finding-the-sum-of-fibonacci-numbers
        private static int FibMatrix(int n, int i, int h, int j, int k)
        {
            while (n > 0)
            {
                int t;
              
                if (n % 2 == 1)
                {
                    t = j * h;
                    j = i * h + j * k + t;
                    i = i * k + t;
                }

                t = h * h;
                h = 2 * k * h + t;
                k = k * k + t;
                n = n / 2;
            }

            return j;
        }

        /// <summary>
        /// Sum of Fibonacci numbers from "n" to "m"
        /// </summary>
        /// <param name="n">The lower boundary of the interval</param>
        /// <param name="m">The upper boundary of the interval</param>
        /// <returns>An Int32 (int) </returns>
        public static int Sum(int n, int m)
        {
            var sum = FibMatrix(n, 1, 1, 0, 0);

            while (n + 1 <= m)
            {
                sum += FibMatrix(n + 1, 1, 1, 0, 0);
                n++;
            }

            return sum;
        }

        //Power series, Recipcol sums, right triangles, asymptotic
    }
}

