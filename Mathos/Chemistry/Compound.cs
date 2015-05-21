using System.Collections.Generic;

namespace Mathos.Chemistry
{
    /// <summary>
    /// A compound contains a set of different elements (see Element class).
    /// </summary>
    public class Compound
    {
        /// <summary>
        /// The set of compounds.
        /// </summary>
        public List<Element> Elements { get; set; }

        /// <summary>
        /// The coefficient that should be in front of the compound, eg. 2H_2O for 2 water molecules.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Creates a new instance of the compound class.
        /// </summary>
        public Compound() : this(1) { }

        /// <summary>
        /// Creates a new instance of the compound class.
        /// <param name="amount">The coefficient that should be in front of the compound, eg. 2H_2O for 2 water molecules.</param>
        /// </summary>
        public Compound(int amount)
        {
            Elements = new List<Element>();
            Amount = amount;
        }
    }
}
