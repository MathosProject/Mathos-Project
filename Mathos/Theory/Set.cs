using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mathos.Theory
{
    /// <summary>
    /// An implementation of sets from set theory.
    /// 
    /// - Needs cartesian product.
    /// - Needs power set.
    /// </summary>
    public class Set<T> : IEnumerable
    {
        /// <summary>
        /// The contents of the set.
        /// </summary>
        public readonly HashSet<T> Elements;

        /// <summary>
        /// Create an empty set.
        /// </summary>
        public Set()
        {
            Elements = new HashSet<T>();
        }

        /// <summary>
        /// Create a set from an already existing set.
        /// </summary>
        /// <param name="s">The base set to copy from.</param>
        public Set(Set<T> s)
        {
            Elements = s.Elements;
        }

        /// <summary>
        /// Create a set from a list of elements.
        /// </summary>
        /// <param name="elements">The elements the set will contain.</param>
        public Set(params T[] elements) : this()
        {
            foreach(var element in elements)
                Elements.Add(element);
        }

        
        /// <summary>
        /// Add an element to the set.
        /// </summary>
        /// <param name="element">The element to add.</param>
        /// <returns>This set with the given element added.</returns>
        public HashSet<T> Add(T element)
        {
            Elements.Add(element);

            return Elements;
        }

        /// <summary>
        /// Add multiple elements to the set.
        /// </summary>
        /// <param name="elements">The elements to add.</param>
        /// /// <returns>This set with the given elements added.</returns>
        public Set<T> Add(params T[] elements)
        {
            foreach(var element in elements)
                Elements.Add(element);

            return this;
        }

        /// <summary>
        /// Add the contents of another set into this one.
        /// </summary>
        /// <param name="b">The base set.</param>
        /// <returns>This set combined with b.</returns>
        public Set<T> Add(Set<T> b)
        {
            foreach(var element in b.Elements)
                Elements.Add(element);

            return this;
        }

        /// <summary>
        /// Remove the given item from the set.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>This set with the given item removed.</returns>
        public Set<T> Remove(T item)
        {
            Elements.Remove(item);

            return this;
        }

        /// <summary>
        /// Remove the item that matches the given expression.
        /// </summary>
        /// <param name="match">The expression to match to.</param>
        /// <returns>This set with the matched item removed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="match" /> is null.</exception>
        public Set<T> RemoveMatch(Predicate<T> match)
        {
            Elements.RemoveWhere(match);

            return this;
        }

        /// <summary>
        /// Get the union of this set and b.
        /// </summary>
        /// <param name="b">The second set.</param>
        /// <returns>this ∪ b.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public Set<T> Union(Set<T> b)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Concat(b.Elements).Where(item => !ret.Elements.Contains(item)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the intersection of this set and b.
        /// </summary>
        /// <param name="b">The second set.</param>
        /// <returns>this ∩ b.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public Set<T> Intersection(Set<T> b)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Where(element => b.Elements.Contains(element)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the difference of this set and b.
        /// </summary>
        /// <param name="b">The second set.</param>
        /// <returns>this \ b.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public Set<T> Difference(Set<T> b)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Where(element => !b.Elements.Contains(element)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the symmetric difference of this set and b.
        /// </summary>
        /// <param name="b">The second set.</param>
        /// <returns>Either (this △ b) or (this ⊖ b).</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public Set<T> Symmetric(Set<T> b)
        {
            var union = Union(b);
            var inter = Intersection(b);

            return union.Difference(inter);
        }

        /// <summary>
        /// Is this set a subset of b?
        /// </summary>
        /// <param name="b">The base set.</param>
        /// <returns>this ⊆ b.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public bool IsSubset(Set<T> b)
        {
            return Elements.IsSubsetOf(b.Elements);
        }

        /// <summary>
        /// Is this set a proper subset of b?
        /// </summary>
        /// <param name="b">The base set.</param>
        /// <returns>this ⊂ b.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="b" /> is null.</exception>
        public bool IsProperSubset(Set<T> b)
        {
            return Elements.IsProperSubsetOf(b.Elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// The enumerator of the set.
        /// </summary>
        /// <returns>The contents of the set.</returns>
        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
        /// <exception cref="ArgumentNullException">Either <paramref name="obj" /> or the set to compare to is null.</exception>
        public override bool Equals(object obj)
        {
            if (!(obj is Set<T>))
                return false;

            return ((Set<T>) obj).Elements.All(arg => Elements.Contains(arg));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return Elements != null ? Elements.GetHashCode() : 0;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override string ToString()
        {
            var str = Elements.Aggregate("{", (current, element) => current + (element.ToString() + ","));

            if (str.EndsWith(","))
                str = str.Substring(0, str.Length - 1);

            return str + "}";
        }
    }
}
