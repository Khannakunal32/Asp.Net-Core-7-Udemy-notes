using MiddlewareExample.CustomMiddleware;

namespace MiddlewareExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /// builder.services add transient is used to create custom middleware 
            builder.Services.AddTransient<MyCustomMiddleware>();
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            /// Note two middle ware ie app.Run( async (HttpContext context) => {}) can't run together
            /// eg...

            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("hello");
            //});

            /////Note the below line don't work as app.run runs only once 

            //app.Run(async (HttpContext context) =>
            //{
            //    await context.Response.WriteAsync("hello again");
            //});

            /// To solve this proble we can do is use app.Use (Note press right click on run or view and see defination you will get to know about it
            /// 
            ///We are creating middle wares and pipelines and jumping from one use to other


            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                await context.Response.WriteAsync("1st middleWare starts and calls second middle ware\n");

                if ("kunal" == "kunal")
                { await next(context); }

                await context.Response.WriteAsync("1st middleware overs\n");
            });

            // here next represent the next middeleware in which we pass the context of previous middleware
            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                //before logic
                await context.Response.WriteAsync("2nd middleware starts and calls 3rd middleware\n");
                await next(context);

                //after logic
                await context.Response.WriteAsync("2nd middleware overs\n");

            });

            /// calling the external customMiddleware
            app.UseMiddleware<MyCustomMiddleware>();

            app.Run(async (HttpContext context) =>
            {
                await context.Response.WriteAsync("3rd middleware starts\n");

                await context.Response.WriteAsync("3nd middleware overs\n");

            });

            app.Run();
        }
    }
}