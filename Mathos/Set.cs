using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Mathos
{
    /// <summary>
    /// Represents a set ({1, 2, 3}, {8, 6, 4}, etc.).
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
        /// Constructor that creates a set from an array of elements.
        /// </summary>
        /// <param name="elements">The set's elements.</param>
        public Set(params T[] elements)
        {
            Elements = new HashSet<T>(elements);
        }

        /// <summary>
        /// Constructor that creates a set from an enumerable object.
        /// </summary>
        /// <param name="elements">The set's elements.</param>
        public Set(IEnumerable<T> elements)
        {
            Elements = new HashSet<T>(elements);
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
            foreach (var element in elements)
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
        public void Remove(Predicate<T> match)
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
            return new Set<T>(Elements.Union(set.Elements));
        }

        /// <summary>
        /// Get the intersection of this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this ∩ <paramref name="set"/>.</returns>
        public Set<T> Intersection(Set<T> set)
        {
            return new Set<T>(Elements.Intersect(set.Elements));
        }

        /// <summary>
        /// Get the difference of this and another set, <paramref name="set"/>.
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
        /// Get the symmetric difference of this and another set, <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The second set.</param>
        /// <returns>this △ <paramref name="set"/>; this ⊖ <paramref name="set"/>.</returns>
        public Set<T> Symmetric(Set<T> set)
        {
            return Difference(this, set).Union(set.Difference(this));
        }

        /// <summary>
        /// Check if this is a subset of <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The subset.</param>
        /// <returns>this ⊆ <paramref name="set"/>.</returns>
        public bool IsSubset(Set<T> set)
        {
            return Elements.IsSubsetOf(set.Elements);
        }

        /// <summary>
        /// Check if this is a proper subset of <paramref name="set"/>.
        /// </summary>
        /// <param name="set">The proper subset.</param>
        /// <returns>this ⊂ <paramref name="set"/>.</returns>
        public bool IsProperSubset(Set<T> set)
        {
            return Elements.IsProperSubsetOf(set.Elements);
        }

        #region Static Methods

        /// <summary>
        /// Get the union of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first set.</param>
        /// <param name="b">The second set.</param>
        /// <returns><paramref name="a"/> ∪ <paramref name="b"/>.</returns>
        public static Set<T> Union(Set<T> a, Set<T> b)
        {
            return a.Union(b);
        }

        /// <summary>
        /// Get the intersection of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <paramref name="a">The first set.</paramref>
        /// <paramref name="b">The second set.</paramref>
        /// <returns><paramref name="a"/> ∩ <paramref name="b"/>.</returns>
        public static Set<T> Intersection(Set<T> a, Set<T> b)
        {
            return a.Intersection(b);
        }

        /// <summary>
        /// Get the difference of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first set.</param>
        /// <param name="b">The second set.</param>
        /// <returns><paramref name="a"/> \ <paramref name="b"/>.</returns>
        public static Set<T> Difference(Set<T> a, Set<T> b)
        {
            return a.Difference(b);
        }

        /// <summary>
        /// Get the symmetric difference of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first set.</param>
        /// <param name="b">The second set.</param>
        /// <returns><paramref name="a"/> △ <paramref name="b"/>.</returns>
        public static Set<T> Symmetric(Set<T> a, Set<T> b)
        {
            return a.Symmetric(b);
        }

        /// <summary>
        /// Check if <paramref name="a"/> is a subset of <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The subset.</param>
        /// <param name="b">The superset.</param>
        /// <returns><paramref name="a"/> ⊆ <paramref name="b"/>.</returns>
        public static bool IsSubset(Set<T> a, Set<T> b)
        {
            return a.IsSubset(b);
        }

        /// <summary>
        /// Check if <paramref name="a"/> is a proper subset of <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The proper subset.</param>
        /// <param name="b">The superset.</param>
        /// <returns><paramref name="a"/> ⊂ <paramref name="b"/>.</returns>
        public static bool IsProperSubset(Set<T> a, Set<T> b)
        {
            return a.IsProperSubset(b);
        }

        #endregion

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
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// True if the specified object is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
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
        public override string ToString()
        {
            var str = Elements.Aggregate("{", (current, element) => current + element.ToString() + ",");

            if (str.EndsWith(","))
                str = str.Substring(0, str.Length - 1);

            return str + "}";
        }
    }
}
