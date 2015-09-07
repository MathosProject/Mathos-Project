namespace Mathos.Chemistry
{
    /// <summary>
    /// This class represents an element. 
    /// </summary>
    public class Element
    {
        /// <summary>
        /// The name of the element.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Create a new element.
        /// </summary>
        /// <param name="name">Name of the element.</param>
        public Element(string name)
        {
            Name = name;
        }
    }
}
