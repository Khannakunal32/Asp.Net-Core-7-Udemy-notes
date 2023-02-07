namespace MiddlewareExample.CustomMiddleware
{

    /// <summary>
    ///  To extend the middleware in program.cs we use interface IMiddleware and use ctr+. to extend the interface
    /// </summary>
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Calling the myCustomMiddleware\n");

            await next(context);

            await context.Response.WriteAsync("going back from mycustomMiddle\n");

        }
    }
}
