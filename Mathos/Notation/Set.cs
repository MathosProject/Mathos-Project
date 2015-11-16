using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mathos.Notation
{
    /// <summary>
    /// Implementation of sets (i.e. A = {1, 2, 3, ...}).
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
        /// Default constructor.
        /// </summary>
        public Set()
        {
            Elements = new HashSet<T>();
        }

        /// <summary>
        /// Constructor that copies the elements from another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The set to copy from.</param>
        public Set(Set<T> set)
        {
            Elements = set.Elements;
        }

        /// <summary>
        /// Constructor that creates a set from a list of elements.
        /// </summary>
        /// <param name="elements">The set's elements.</param>
        public Set(params T[] elements) : this()
        {
            foreach(var element in elements)
                Elements.Add(element);
        }

        
        /// <summary>
        /// Add an element.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Add(T element)
        {
            Elements.Add(element);
        }

        /// <summary>
        /// Add multiple elements to the set.
        /// </summary>
        /// <param name="elements">The elements to add.</param>
        public void Add(params T[] elements)
        {
            foreach(var element in elements)
                Elements.Add(element);
        }

        /// <summary>
        /// Add the elements of another set.
        /// </summary>
        /// <param name="set">The set to copy from.</param>
        public void Add(Set<T> set)
        {
            foreach(var element in set.Elements)
                Elements.Add(element);
        }

        /// <summary>
        /// Remove an element.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        public void Remove(T element)
        {
            Elements.Remove(element);
        }

        /// <summary>
        /// Remove elements that <paramref name="match"/> the given predicate.
        /// </summary>
        /// <param name="match">The conditions for removal.</param>
        public void RemoveMatch(Predicate<T> match)
        {
            Elements.RemoveWhere(match);
        }

        /// <summary>
        /// Get the union of this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this ∪ <paramref name="set"/>.</returns>
        public Set<T> Union(Set<T> set)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Concat(set.Elements).Where(item => !ret.Elements.Contains(item)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the intersection of this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this ∩ <paramref name="set"/>.</returns>
        public Set<T> Intersection(Set<T> set)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Where(element => set.Elements.Contains(element)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the difference between this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this \ <paramref name="set"/>.</returns>
        public Set<T> Difference(Set<T> set)
        {
            var ret = new Set<T>();

            foreach (var element in Elements.Where(element => !set.Elements.Contains(element)))
                ret.Add(element);

            return ret;
        }

        /// <summary>
        /// Get the symmetric difference between this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this △ <paramref name="set"/>; this ⊖ <paramref name="set"/>.</returns>
        public Set<T> Symmetric(Set<T> set)
        {
            var union = Union(set);
            var inter = Intersection(set);

            return union.Difference(inter);
        }

        /// <summary>
        /// Check if this is a subset of <paramref name="set"/>
        /// </summary>
        /// <param name="set">The superset to check under.</param>
        /// <returns>this ⊆ <paramref name="set"/>.</returns>
        public bool IsSubset(Set<T> set)
        {
            return Elements.IsSubsetOf(set.Elements);
        }

        /// <summary>
        /// Check if this is a proper subset of <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this ⊂ <paramref name="set"/>.</returns>
        public bool IsProperSubset(Set<T> set)
        {
            return Elements.IsProperSubsetOf(set.Elements);
        }

        /// <summary>
        /// The enumerator of the set.
        /// </summary>
        /// <returns>The contents of the set.</returns>
        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <filterpriority>2</filterpriority>
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
        public override string ToString()
        {
            var str = Elements.Aggregate("{", (current, element) => current + (element.ToString() + ","));

            if (str.EndsWith(","))
                str = str.Substring(0, str.Length - 1);

            return str + "}";
        }
    }
}
