using System.Diagnostics;

namespace MisTest.Host.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var request = context.Request;

            _logger.LogInformation(
                "HTTP {Method} {Path} {QueryString} started from {IpAddress}",
                request.Method,
                request.Path,
                request.QueryString.HasValue ? request.QueryString.Value : string.Empty,
                context.Connection.RemoteIpAddress);

            var originalBodyStream = context.Response.Body;

            await _next(context);

            stopwatch.Stop();
            _logger.LogInformation(
                "HTTP {Method} {Path} completed with {StatusCode} in {ElapsedMs}ms",
                request.Method,
                request.Path,
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);
        }

    }
}
