namespace MiddlewareAdvance.CustomMiddleware
{
    public class MiddlewareExtended : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            await context.Response.WriteAsync("3rd Middleware Extended\n");

            await next(context);

            await context.Response.WriteAsync("3rd Middleware Extended\n");
        }
    }

    /// We are creating an extension of this middle ware and implementing in the app.(...) so that we can use it as a function 
    /// go and see the defination of build ie app = builder.build(); we will see the return type of build is webApplication and if we see the defination of the webAppliction it has interface of iApplicationBuilder and if we include it in iApplication builder we can get the function inside app and use it directly in program.cs
    /// 

    /// Note extension is always of static type
    public static class MiddlewareExtendedExtension
    {
        public static IApplicationBuilder UseMiddlewareExtended(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MiddlewareExtended>();
        }
    }
}
