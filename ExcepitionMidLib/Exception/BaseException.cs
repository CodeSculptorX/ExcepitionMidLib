#nullable disable
using Microsoft.Extensions.Logging;
using System.Net;

namespace ExcepitionMidLib.Exception
{
    public abstract class BaseException : System.Exception
    {
        public BaseException(HttpStatusCode httpCode, int errorCode, string errorMessage, System.Exception exception, ILogger logger = null) : base(exception.Message, exception) 
        {
            HttpCode = (int)httpCode;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Logger = logger;

        }

        public BaseException(HttpStatusCode httpCode, int errorCode, string errorMessage, ILogger logger = null) : base()
        {
            
            HttpCode = (int)httpCode;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            Logger = logger;
        }

        protected BaseException() { }

        /// <summary>
        /// Logger instance of the class where the error occured.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// HTTP status responce class.
        /// </summary>
        public int HttpCode { get; set; }

        /// <summary>
        /// Code for error encountered.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Error message of API.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns a formatted error message.
        /// </summary>
        /// <returns>Error message object.</returns>
        public abstract Error GetFormattedError();
    }
}
