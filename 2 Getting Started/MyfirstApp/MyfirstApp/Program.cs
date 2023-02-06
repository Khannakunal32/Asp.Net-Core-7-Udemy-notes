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


                // we can store the path of the current page like localhost/kunalkhanna and write if else condition on the basis of it
                string path = context.Request.Path;
                string method = context.Request.Method;

                await context.Response.WriteAsync($"<p>{path}</p> <p>{method}</p>");

                if (path == "/KunalKhanna" || path == "/kunalkhanna")
                {
                    context.Response.Redirect("https://bractus.com");
                }

                //Query String
                // ie localhost?id=10&name=kunal the content after ? is query string ie is passed in case of GET request and for POST request this is not shown and pass in the form of request body

                if (context.Request.Method == "GET")
                {

                    if (context.Request.Query.ContainsKey("id")) // contains key is to check if the key in passed argument is present
                    {
                        string id = context.Request.Query["id"]; // request query stores the value of the key in the string
                        await context.Response.WriteAsync($"<p>id = {id}</p>");
                    }

                    if (context.Request.Query.ContainsKey("test"))
                    {
                        string test = context.Request.Query["test"];
                        await context.Response.WriteAsync($"<p>test = {test}</p>");
                    }

                    // now check writing in browser https://localhost:7292/?id=2&test=kunal
                }

            });

            app.Run();
        }
    }
}