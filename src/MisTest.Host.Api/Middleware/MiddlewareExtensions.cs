namespace MisTest.Host.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleWarePipeline(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandlingMiddleware>();
            builder.UseMiddleware<RequestLoggingMiddleware>();
            return builder;
        }
    }
}
