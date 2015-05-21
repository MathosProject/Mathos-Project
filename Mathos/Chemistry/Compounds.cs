using System.Collections.Generic;
using System.Linq;

namespace Mathos.Chemistry
{
    // do we need this class at all?

    /// <summary>
    /// Represents a set of compunds. This can be thought of as the LHS and RHS of a chemical equation.
    /// </summary>
    public class Compounds
    {
        /// <summary>
        /// The set of compounds
        /// </summary>
        public List<Compound> SetOfCompounds { get; set; }

        /// <summary>
        /// Creates a new instance of the compounds class.
        /// </summary>
        public Compounds()
        {
            SetOfCompounds = new List<Compound>();
        }
        
        /// <summary>
        /// Number of unique elements in a list of compounds.
        /// </summary>
        /// <returns></returns>
        public int NumberOfUniqueElements()
        {
            // this has to be optimized a lot. This will prorably be O(n^2) if not worse.
            var recordedElements = new List<Element>(); // maybe better with HashMap here.

            foreach (var element in from compound in SetOfCompounds
                from element in compound.Elements
                where !recordedElements.Contains(element)
                select element)
            {
                recordedElements.Add(element);
            }

            return recordedElements.Count();
        }

    }

    /// <summary>
    /// Specifies whether the set of compounds are reactants [maybe we don't need this as a set of compunds can be reactants in one equation and products in another.]
    /// </summary>
    public enum CompoundsType
    {
        Reactants,
        Products
    }
}
