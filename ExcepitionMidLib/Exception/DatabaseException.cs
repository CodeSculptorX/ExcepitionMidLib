using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExcepitionMidLib.Exception
{
    public class DatabaseException : ApiException
    {
        /// <summary>
        /// Defult error code for database.
        /// </summary>
        internal static int DefaultErrorCode { get; set; }

        /// <summary>
        /// Creates an instances of type <see cref="DatabaseException"/>
        /// </summary>
        /// <param name="errocode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="logger">Logger instance.</param>
        /// <param name="exception">Exception message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public DatabaseException(ILogger logger, int errocode, string errorMessage, System.Exception exception ,params string[] args)
        : base (exception, logger,HttpStatusCode.BadRequest,errocode, errorMessage, args) { }

        /// <summary>
        /// Creates an instances of type <see cref="DatabaseException"/>
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="logger">Logger instance.</param>
        /// <param name="exception">Exception message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public DatabaseException(ILogger logger, string errorMessage, System.Exception exception, params string[] args)
        : base(exception, logger, HttpStatusCode.BadRequest, DefaultErrorCode, errorMessage, args) { }

        /// <summary>
        /// Creates an instances of type <see cref="DatabaseException"/>
        /// </summary>
        /// <param name="errocode">Internal API error code.</param>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="exception">Exception message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public DatabaseException(int errocode,string errorMessage, System.Exception exception, params string[] args)
        : base(exception, HttpStatusCode.BadRequest, errocode, errorMessage, args) { }

        /// <summary>
        /// Creates an instances of type <see cref="DatabaseException"/>
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <param name="exception">Exception message.</param>
        /// <param name="args">Arguemtns to phrase error message</param>
        public DatabaseException(string errorMessage, System.Exception exception, params string[] args)
        : base(exception, HttpStatusCode.BadRequest, DefaultErrorCode, errorMessage, args) { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc>/></returns>
        public override Error GetFormattedError()
        => new Error(ErrorCode, ErrorMessage, Arguments);

    }
}
