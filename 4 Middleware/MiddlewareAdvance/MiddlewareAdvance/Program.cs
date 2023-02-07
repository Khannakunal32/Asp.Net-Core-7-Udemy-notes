using MiddlewareAdvance.CustomMiddleware;

namespace MiddlewareAdvance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // we need to create transient for all middlewares added
            builder.Services.AddTransient<MiddlewareScratch>();
            builder.Services.AddTransient<MiddlewareExtended>();

            // we do not need to create a transient when using template of middleware
            //builder.Services.AddTransient<MiddlewareTemplate>();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("1st Middleware\n");
                await next(context);
                await context.Response.WriteAsync("~ 1st Middleware\n");
            });

            // Second middleware made from scratch using iMiddleware interface
            app.UseMiddleware<MiddlewareScratch>();

            // Third middleware made using Extension of iApplicationBuilder and iMiddleware interface
            app.UseMiddlewareExtended();

            // Fourth middleware made from template of middleware 
            app.UseMiddlewareTemplate();

            app.UseWhen(context => context.Request.Query.ContainsKey("username"),
                app =>
                {
                    app.Use(async (context, next) =>
                    {
                        string UserName = context.Request.Query["username"];
                        await context.Response.WriteAsync($"\nHello {UserName} \n\n");
                        await next();
                    });
                });


            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync(" Middleware\n");
                await next(context);
                await context.Response.WriteAsync("~ Middleware\n");
            });



            app.Run();
        }
    }
}