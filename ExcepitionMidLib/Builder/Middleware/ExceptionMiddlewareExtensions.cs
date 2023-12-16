#nullable disable
using ExcepitionMidLib.Exception;
using ExcepitionMidLib.Middleware.ExceptionHandler;
using Microsoft.AspNetCore.Builder;

namespace ExcepitionMidLib.Builder.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UserExceptionHandler(this IApplicationBuilder app, Action<ExceptionOptions> options = null) 
        {
            var exceptionConfig = new ExceptionOptions();
            options?.Invoke(exceptionConfig);
            DatabaseException.DefaultErrorCode = exceptionConfig.DefaultDatabaseErrorCode;
            APIExceptionResponceMiddleware.InternalServerErrorCode = exceptionConfig.DefaultInternalServerErrorCode;
            app.UseMiddleware<APIExceptionResponceMiddleware>();
            return app;
        }
    }
}
