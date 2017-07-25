using System;
using System.Text;

namespace Mathos.Statistics
{
    /// <summary>
    /// Simulate dice rolls.
    /// </summary>
    public class DiceSimulator
    {
        /// <summary>
        /// The values of the dice after being rolled.
        /// </summary>
        /// <seealso cref="Roll"/>
        /// <seealso cref="SumDiceRoll"/>
        /// <seealso cref="MaxDiceRoll"/>
        /// <seealso cref="DiffDiceRoll"/>
        public readonly int[] RolledValues;

        private readonly int _seed;
        private readonly int _numDice;
        
        private readonly Random _rnd;

        /// <summary>
        /// Constructor that takes <paramref name="nDice"/> as the number of dice to roll.
        /// </summary>
        /// <param name="nDice">The number of dice to roll.</param>
        public DiceSimulator(int nDice)
            : this(nDice, (int) DateTime.Now.Ticks)
        {
        }

        /// <summary>
        /// Constructor that takes <paramref name="nDice"/> as the number of dice to roll and a given <paramref name="seed"/>.
        /// </summary>
        /// <param name="nDice">The number of dice to roll.</param>
        /// <param name="seed">The seed to use when simulating rolls.</param>
        public DiceSimulator(int nDice, int seed)
        {
            _seed = seed;
            _numDice = nDice;
            RolledValues = new int[_numDice];

            _rnd = new Random(seed);

            for (var i = 0; i < _numDice; i++)
                Roll(i);
        }

        /// <summary>
        /// Rolls the die at index <paramref name="nDieIndex"/>.
        /// </summary>
        /// <param name="nDieIndex">The index of the die to roll.</param>
        /// <returns>The rolled value (1-6).</returns>
        public int Roll(int nDieIndex)
        {
            System.Diagnostics.Trace.TraceInformation("  Seedval: " + _seed);
            
            Math.DivRem(_rnd.Next(), 6, out int nResult);

            RolledValues[nDieIndex] = nResult + 1;

            return RolledValues[nDieIndex];
        }

        /// <summary>
        /// Rolls all the dice and returns the sum of their values.
        /// </summary>
        /// <returns>The sum of all dice after rolls.</returns>
        public int SumDiceRoll()
        {
            var nSum = 0;

            for (var i = 0; i < _numDice; i++)
                nSum += RolledValues[i];

            return nSum;
        }

        /// <summary>
        /// Rolls all the dice and returns the maximum.
        /// </summary>
        /// <returns>The maximum of the rolled dice.</returns>
        public int MaxDiceRoll()
        {
            var nMax = 0;

            for (var i = 0; i < _numDice; i++)
                nMax = Math.Max(nMax, RolledValues[i]);

            return nMax;
        }

        /// <summary>
        /// Rolls all the dice and subtracts them using sequency ABS diff.
        /// </summary>
        /// <returns>The value of the rolled dice after being subtracted.</returns>
        public int DiffDiceRoll()
        {
            var nSub = 0;

            for (var i = 0; i < _numDice; i++)
                nSub = Math.Abs(nSub - RolledValues[i]);

            return nSub;
        }

        /// <summary>
        /// Convert the dice simulation into a string.
        /// </summary>
        /// <returns>The string version of the dice simulation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">There are too many dice; the resulting string would be larger than <see cref="P:System.Text.StringBuilder.MaxCapacity" />.</exception>
        public override string ToString()
        {
            var dceInfo = new StringBuilder();

            for (var i = 0; i < _numDice; i++)
                dceInfo.AppendLine(" Dice " + i + ":" + RolledValues[i]);

            return dceInfo.ToString();
        }

        /// <summary>
        /// Gets the die at index <paramref name="p"/>.
        /// </summary>
        /// <param name="p">The index to get from.</param>
        /// <exception cref="ArgumentException" accessor="get"><paramref name="p"/> is greater than the number of dice.</exception>
        public int this[int p]
        {
            get
            {
                if (p > _numDice)
                    throw new ArgumentException("This does not represent a valid dice index");

                return RolledValues[p];
            }
        }
    }
}
