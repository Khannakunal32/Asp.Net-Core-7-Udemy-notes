namespace MyfirstApp
{

    /// <summary>
    /// Creating the first app by chosing -> New project -> empty Asp.net core empty -> remove configure for http and start the project
    /// </summary>
    /// 

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            //working with status code
            app.Run(async (HttpContext context) =>
            {
                if ("kunal" == "kunal")
                {
                    //the below line means the content-type to send is a text / html type that is we can send html tags in write async
                    context.Response.Headers["Content-Type"] = "text/html";

                    //working with status code
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Status Code is 400");
                    //working with response headers
                    context.Response.Headers["myKey"] = "my Value";

                    // the below line means the content-type to send is a text/html type that is we can send html tags in write async
                    await context.Response.WriteAsync("<h1>Kali linux is the best</h1>");
                }
                else
                {
                    //working with status code
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Status Code is 500");
                }


                // we cans 
                string path = context.Request.Path;
                string method = context.Request.Method;

                await context.Response.WriteAsync($"<p>{path}</p> <p>{method}</p>");

                if (path == "/KunalKhanna" || path == "/kunalkhanna")
                {
                    context.Response.Redirect("https://bractus.com");
                }

            });

            app.Run();
        }
    }
}