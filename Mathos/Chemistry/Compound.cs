using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathos.Chemistry
{
    /// <summary>
    /// A compound contains a set of different elements (see Element class).
    /// </summary>
    public class Compound
    {
        /// <summary>
        /// The elements this compound is made of.
        /// </summary>
        public List<Element> Elements { get; set; }
        
        /// <summary>
        /// Create an empty compound.
        /// </summary>
        public Compound() : this(new List<Element>())
        {
        }

        /// <summary>
        /// Create a new compound.
        /// </summary>
        /// <param name="elements">The elements the compound will be made of.</param>
        public Compound(IEnumerable<Element> elements)
        {
            Elements = elements.ToList();
        }

        /// <summary>
        /// Create a new compound.
        /// </summary>
        /// <param name="elements">The elements the compound will be made of.</param>
        public Compound(params Element[] elements) : this(elements.ToList())
        {
        }

        /// <summary>
        /// Create a new compound.
        /// </summary>
        /// <param name="e1">The elements the compound will be made of.</param>
        /// <param name="e2">The elements the compound will be made of.</param>
        public Compound(IEnumerable<Element> e1, params Element[] e2) : this(e1.Concat(e2))
        {
        }

        /// <summary>
        /// Check whether the given object is equal to this compound.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>Is the given object is equal to this compound?</returns>
        public override bool Equals(object obj)
        {
            var compound = obj as Compound;

            if (compound == null)
                return false;

            return compound.Elements == Elements;
        }

        /// <summary>
        /// Gets the compound's hashcode.
        /// </summary>
        /// <returns>The compound's hashcode.</returns>
        public override int GetHashCode()
        {
            return Elements.GetHashCode();
        }

        /// <summary>
        /// Get the compound's formula.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            var elements = new Dictionary<string, int>();

            foreach (var name in Elements.Select(element => element.Name))
            {
                if (elements.ContainsKey(name))
                    elements[name]++;
                else
                    elements.Add(name, 1);
            }

            foreach (var element in elements)
                builder.Append(element.Key + ((element.Value > 1) ? element.Value.ToString() : "") + " ");

            var ret = builder.ToString();

            if (ret.EndsWith(" "))
                ret = ret.Substring(0, ret.Length - 1);

            return ret;
        }
    }
}
