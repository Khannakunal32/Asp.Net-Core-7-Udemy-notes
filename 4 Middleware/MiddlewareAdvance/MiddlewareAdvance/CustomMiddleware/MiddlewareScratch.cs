namespace MiddlewareAdvance.CustomMiddleware
{
    public class MiddlewareScratch : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("2nd Middleware Scratch\n");

            await next(context);

            await context.Response.WriteAsync("2nd Middleware Scratch\n");
        }
    }
}
