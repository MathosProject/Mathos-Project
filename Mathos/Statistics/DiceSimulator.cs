using System;

namespace Mathos.Statistics
{
    /// <summary>
    /// Simulate dice rolls.
    /// </summary>
    public class DiceSimulator
    {
        private readonly int _numDice;
        private readonly int[] _nRolledValue; //= new int[6];
        private readonly int _seed = (int)(DateTime.Now.Ticks);
        
        private readonly Random _rnd;

        /// <summary>
        /// Constructor that takes "nDice" as the number of dice and goes upto 6 dice
        /// </summary>
        /// <param name="nDice"></param>
        public DiceSimulator(int nDice)
        {
            _numDice = nDice;
            _nRolledValue = new int[_numDice];          //permits to create an arbitrary number of dices
            _rnd = new Random(_seed);

            for (var i = 0; i < _numDice; i++)
                Roll(i);
        }

        /// <summary>
        /// Convert the dice simulation into a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var dceInfo = "";

            for (var i = 0; i < _numDice; i++)
                dceInfo += " Dice " + i + ":" + _nRolledValue[i];

            return dceInfo;
        }

        /// <summary>
        /// Rolls the dice "nDiceIndex" indicates which if more than one, if only 1, then no parameter is required
        /// </summary>
        /// <param name="nDiceIndex"></param>
        /// <returns></returns>
        public int Roll(int nDiceIndex)
        {
            System.Diagnostics.Trace.TraceInformation("  Seedval: " + _seed);

            int nResult;

            Math.DivRem(_rnd.Next(), 6, out nResult);

            _nRolledValue[nDiceIndex] = nResult + 1;

            return _nRolledValue[nDiceIndex];
        }
        /// <summary>
        /// Rolls the "nDice" and sums them
        /// </summary>
        /// <returns></returns>
        public int SumDiceRoll()
        {
            var nSum = 0;

            for (var i = 0; i < _numDice; i++)
                nSum += _nRolledValue[i];

            return nSum;
        }

        /// <summary>
        /// Rolls the "nDice" and then finds the maximum
        /// </summary>
        /// <returns></returns>
        public int MaxDiceRoll()
        {
            var nMax = 0;

            for (var i = 0; i < _numDice; i++)
                nMax = Math.Max(nMax, _nRolledValue[i]);

            return nMax;
        }

        /// <summary>
        /// Rolls the "nDice" and then subtracts them (using sequency ABS diff)
        /// </summary>
        /// <returns></returns>
        public int DiffDiceRoll()
        {
            var nSub = 0;

            for (var i = 0; i < _numDice; i++)
                nSub = Math.Abs(nSub - _nRolledValue[i]);

            return nSub;
        }

        /// <summary>
        /// Implementation of an indexer to retrieve any rolled dice at any time
        /// </summary>
        /// <param name="p"></param>
        /// <exception cref="ArgumentException"></exception>
        public int this[int p]
        {
            get
            {
                if (p > _numDice)
                    throw new ArgumentException("This does not represent a valid dice index");

                return _nRolledValue[p];
            }
        }
    }
}
