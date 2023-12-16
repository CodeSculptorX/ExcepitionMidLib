using Microsoft.Extensions.Logging;
using System.Net;

namespace ExcepitionMidLib.Exception
{
    /// <summary>
    /// Custom exception to handle api errors.
    /// </summary>
    public class ApiException : BaseException
    {
        /// <summary>
        /// Arguments to phrase error message
        /// </summary>
        public string[] Arguments { get; set; }

        /// <summary>
        /// Creates an instances of type <see cref="ApiException"/>
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="httpCode">HTTP error code.</param>
        /// <param name="errocode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public ApiException(ILogger logger, HttpStatusCode httpCode, int errocode, string errorMessage, params string[] args) 
        : base(httpCode, errocode, errorMessage, logger)
            => Arguments = args;

        /// <summary>
        /// Creates an instances of type <see cref="ApiException"/>
        /// </summary>
        /// <param name="exception">Exception object</param>
        /// <param name="logger">Logger instance.</param>
        /// <param name="httpCode">HTTP error code.</param>
        /// <param name="erroCode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public ApiException(System.Exception exception, ILogger logger, HttpStatusCode httpCode, int erroCode, string errorMessage, params string[] args) : base(httpCode, erroCode, errorMessage,exception ,logger)
            => Arguments = args;

        /// <summary>
        /// Creates an instances of type <see cref="ApiException"/>
        /// </summary>
        /// <param name="httpCode">HTTP error code.</param>
        /// <param name="errocode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public ApiException(HttpStatusCode httpCode, int errocode, string errorMessage, params string[] args)
        : base(httpCode, errocode, errorMessage)
            => Arguments = args;

        /// <summary>
        /// Creates an instances of type <see cref="ApiException"/>
        /// </summary>
        /// <param name="httpCode">HTTP error code.</param>
        /// <param name="erroCode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public ApiException(System.Exception exception,HttpStatusCode httpCode, int erroCode, string errorMessage, params string[] args) : base(httpCode, erroCode, errorMessage, exception)
            => Arguments = args;

        public override Error GetFormattedError()
        => new Error(ErrorCode,ErrorMessage, Arguments);

    }
}
