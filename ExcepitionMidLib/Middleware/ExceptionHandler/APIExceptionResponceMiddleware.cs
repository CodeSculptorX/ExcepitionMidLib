#nullable disable
using ExcepitionMidLib.Common;
using ExcepitionMidLib.Exception;
using ExcepitionMidLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mime;

namespace ExcepitionMidLib.Middleware.ExceptionHandler
{
    internal class APIExceptionResponceMiddleware
    {
        private readonly ILogger<APIExceptionResponceMiddleware> _logger;
        private readonly RequestDelegate next;

        internal static int InternalServerErrorCode;

        /// <summary>
        /// Creates an instance of <see cref="APIExceptionResponceMiddleware"/>
        /// </summary>
        /// <param name="next">Delegate to process the http request.</param>
        /// <param name="logger">Instance of <see cref="ILogger"/></param>
        public APIExceptionResponceMiddleware(RequestDelegate next,ILogger<APIExceptionResponceMiddleware> logger)
        {
            _logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(System.Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, System.Exception ex)
        {
            string errorMessage;
            var errorMesg = new HttpActionResponce();

            //Create Error message
            if (ex is BaseException)
            {
                var exception = ex as BaseException;
                var error = exception.GetFormattedError();
                errorMesg.TrackingId = error.Id;
                errorMesg.UserMessage = error.Message;
                errorMesg.DeveloperMessage = ex.InnerException?.Message;
                errorMesg.StatusCode = error.Code;
                context.Response.StatusCode = exception.HttpCode;
            }
            else
            {
                var error = new Error(InternalServerErrorCode, ex.Message);
                errorMesg.TrackingId = error.Id;
                errorMesg.UserMessage = Constants.JsonKey_Global_ErrorMessage;
                errorMesg.DeveloperMessage = error.Message;
                errorMesg.StatusCode = error.Code;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            //Error response builder
            errorMessage = JsonConvert.SerializeObject(errorMesg);

            //Log Error 
            _logger?.LogError(errorMessage);

            //Responce as Json
            context.Response.ContentType = MediaTypeNames.Application.Json;

            //Add message to the return responce from API;
            return context.Response.WriteAsync(errorMessage);
        }
    }
}
