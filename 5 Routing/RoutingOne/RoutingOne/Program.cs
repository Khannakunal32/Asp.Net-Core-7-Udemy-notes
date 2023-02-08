namespace RoutingOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            // enable routing and selects an appropirate end point based on the url path and HTTP method
            app.UseRouting();

            app.Use(async (HttpContext context, RequestDelegate next) =>
            {
                /// Define GetEndpoint after routing as first recogniation and selection is done before getting the information
                Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint(); //getEndpoint store the endpoint that is eefined in useEndpoint and shows

                if (endPoint != null)
                {
                    await context.Response.WriteAsync($"Endpoint:{endPoint.DisplayName}\n");
                }
                await next(context);
                string path = context.Request.Path;
                await context.Response.WriteAsync("path - " + path + "\n");

            });


            //Executes the appropiate endpooint based on the endpo8int selected by userRouting
            app.UseEndpoints(endpoints =>
            {
                // send request on all get or post request
                endpoints.Map("/map", async context =>
                {
                    string path = context.Request.Path;
                    await context.Response.WriteAsync(path + " through any GET or POST or Delete...\n");
                });

                // only send request on get request
                endpoints.MapGet("/map1", async context =>
                {
                    string path = context.Request.Path;
                    await context.Response.WriteAsync(path + " through GET\n"); // Note if path is /name but we use a post request we get an status -> 405 method not allowed
                });

                // only send request on post request
                endpoints.MapPost("/map2", async context =>
                {
                    string path = context.Request.Path;
                    await context.Response.WriteAsync(path + " through POST\n"); // Note if path is /name but we use a post request we get an status -> 405 method not allowed
                });

                // below {} is the route values excessed by request.RouteValues
                endpoints.Map("extended/{filename}.{exTeNsion}", async context =>
                {

                    string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
                    string? extension = Convert.ToString(context.Request.RouteValues["extension"]); // upper or lower case doesnt matter
                    await context.Response.WriteAsync($"file name - {fileName}\nextension - {extension}\n");
                });

                //default parameter below
                endpoints.Map("default/{name=kunal}", async context =>
                {

                    string? Name = Convert.ToString(context.Request.RouteValues["name"]);

                    await context.Response.WriteAsync($"file name - {Name}\n");
                });

                //optional parameter below 
                endpoints.Map("optional/{id?}", async context =>
                {
                    // convert.toInt32 converts null value to 0 , we can use debugging here and check in immediate window the value is actually null by typing context.request.routvalues["id"];

                    if (context.Request.RouteValues.ContainsKey("id"))
                    {
                        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                        await context.Response.WriteAsync($"id - {id}\n");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"id details is not supplied");
                    }


                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"No Route matched at {context.Request.Path} \n");
            });
            app.Run();
        }
    }
}