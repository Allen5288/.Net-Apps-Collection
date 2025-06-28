using System.Diagnostics;

namespace MoocApi.MiddleWares
{

    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(
       RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 记录请求开始时间
            var startTime = Stopwatch.GetTimestamp();
            Console.WriteLine($"Request started: {context.Request.Method} {context.Request.Path} at {DateTime.Now}");
            // 调用下一个中间件（控制器处理）
            await _next(context);
            // 计算请求处理耗时
            var elapsedMs = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine($"Request completed: {context.Request.Method} " +
                $"{context.Request.Path} | Status: {context.Response.StatusCode} | Duration: {elapsedMs}ms");
        }
    }
}
