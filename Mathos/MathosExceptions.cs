using System;
using System.Runtime.Serialization;

namespace Mathos
{
    namespace Exceptions
    {
        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class DenominatorNullException : Exception
        {
            // occurs when assigning denominator value zero
            /// <summary>
            /// Default constructor
            /// </summary>
            public DenominatorNullException() { }
            
            /// <summary>
            /// Constructor that takes a "message"
            /// </summary>
            /// <param name="message"></param>
            public DenominatorNullException(string message) : base(message) { }
            
            /// <summary>
            /// Constructor that takes a "message" with a specified exception, "inner"
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public DenominatorNullException(string message, Exception inner) : base(message, inner) { }

            /// <summary>
            /// A protected constructor that takes serialization "info" alongside a streaming "context"
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            /// <exception cref="ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
            /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
            protected DenominatorNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        /// <summary>
        /// Occurs when the format of the coordinate in the string variable is invalid during the implicit conversion
        /// </summary>
        [Serializable]
        public class InvalidCoordinateFormat : Exception
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public InvalidCoordinateFormat() { }

            /// <summary>
            /// Constructor that takes a "message"
            /// </summary>
            /// <param name="message"></param>
            public InvalidCoordinateFormat(string message) : base(message) { }
            
            /// <summary>
            /// Constructor that takes a "message" with a specified exception, "inner"
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public InvalidCoordinateFormat(string message, Exception inner) : base(message, inner) { }

            /// <summary>
            /// A protected constructor that takes serialization "info" alongside a streaming "context"
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            /// <exception cref="ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
            /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
            protected InvalidCoordinateFormat(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        /// <summary>
        /// Occurs when the format of the fraction in the string variable is invalid during the implicit conversion
        /// </summary>
        [Serializable]
        public class InvalidFractionFormatException : Exception
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public InvalidFractionFormatException() { }
            
            /// <summary>
            /// Constructor that takes a "message"
            /// </summary>
            /// <param name="message"></param>
            public InvalidFractionFormatException(string message) : base(message) { }
            
            /// <summary>
            /// Constructor that takes a "message" with a specified exception, "inner"
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public InvalidFractionFormatException(string message, Exception inner) : base(message, inner) { }

            /// <summary>
            /// A protected constructor that takes serialization "info" alongside a streaming "context"
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            /// <exception cref="ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
            /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
            protected InvalidFractionFormatException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }

        /// <summary>
        /// 
        /// </summary>
        [Serializable]
        public class InvalidTriangleException : Exception
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public InvalidTriangleException() { }

            /// <summary>
            /// Constructor that takes a "message"
            /// </summary>
            /// <param name="message"></param>
            public InvalidTriangleException(string message) : base(message) { }
            
            /// <summary>
            /// Constructor that takes a "message" with a specified exception, "inner"
            /// </summary>
            /// <param name="message"></param>
            /// <param name="inner"></param>
            public InvalidTriangleException(string message, Exception inner) : base(message, inner) { }

            /// <summary>
            /// A protected constructor that takes serialization "info" alongside a streaming "context"
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            /// <exception cref="ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
            /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
            protected InvalidTriangleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }
}
