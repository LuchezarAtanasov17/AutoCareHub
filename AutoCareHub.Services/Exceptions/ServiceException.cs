using System.Runtime.Serialization;

namespace AutoCareHub.Services.Exceptions
{
    /// <summary>
    /// Represents a service exception.
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class.
        /// </summary>
        public ServiceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class with specified message.
        /// </summary>
        public ServiceException(string? message) : base(message)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class with specified message and/or inner exception.
        /// </summary>
        public ServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceException"/> class with specified serialization info and streaming context.
        /// </summary>
        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
