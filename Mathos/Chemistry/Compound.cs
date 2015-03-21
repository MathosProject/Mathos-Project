using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Mathos.Chemistry;

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
        /// <param name="Amount">The coefficient that should be in front of the compound, eg. 2H_2O for 2 water molecules.</param>
        /// </summary>
        public Compound(int Amount)
        {
            this.Elements = new List<Element>();
            this.Amount = Amount;
        }
    }
}
