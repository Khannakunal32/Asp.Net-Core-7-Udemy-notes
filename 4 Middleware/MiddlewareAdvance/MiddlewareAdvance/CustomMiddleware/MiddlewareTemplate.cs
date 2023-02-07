/// Here standard form of taking iMiddleware interface is ommited by using delegate of next 
namespace MiddlewareAdvance.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareTemplate
    {
        private readonly RequestDelegate _next;

        public MiddlewareTemplate(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //before code
            await httpContext.Response.WriteAsync("3rd Middleware Template\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("3rd Middleware Template\n");
            //After code
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareTemplateExtensions
    {
        public static IApplicationBuilder UseMiddlewareTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareTemplate>();
        }
    }
}
