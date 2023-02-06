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
                //the below line means the content-type to send is a text / html type that is we can send html tags in write async
                context.Response.Headers["Content-Type"] = "text/html"; // Header is a Dictionay data structure in c#
                if ("kunal" == "kunal")
                {


                    context.Response.StatusCode = 202; //working with status code
                    await context.Response.WriteAsync("Status Code is 202");

                    context.Response.Headers["myKey"] = "my Value";  //working with response headers

                    // the below line means the content-type to send is a text/html type that is we can send html tags in write async
                    await context.Response.WriteAsync("<h1>Kali linux is the best</h1>");
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
                        string id = context.Request.Query["id"]; // request query stores the value of the key in the string, query is a type of dictionary in c#
                        await context.Response.WriteAsync($"<p>id = {id}</p>");
                    }

                    if (context.Request.Query.ContainsKey("test"))
                    {
                        string test = context.Request.Query["test"];
                        await context.Response.WriteAsync($"<p>test = {test}</p>");
                    }

                    // now check writing in browser https://localhost:7292/?id=2&test=kunal
                }

                //if (context.Request.Headers.ContainsKey("User-Agent"))
                //{

                //    string userAgent = context.Request.Headers["User-Agent"];

                //    //finding a part of string in c# using index of and substring
                //    int startIndex = userAgent.IndexOf("Mozilla");
                //    int endIndex = userAgent.IndexOf("(", startIndex);

                //    string displayString = userAgent.Substring(startIndex, endIndex - startIndex);

                //    await context.Response.WriteAsync($"<p>User-Agent = {displayString}</p>");

                //}


                /// Note we can create our own Header key value pair in browser with the use of POST MAN
                /// go to post man get request and in headers add your own key and then value and press send the code below will be shown
                //if (context.Request.Headers.ContainsKey("Post-Man-Generated-Header"))
                //{
                //    string postManHeaderDisplay = context.Request.Headers["Post-Man-Generated-Header"];
                //    await context.Response.WriteAsync($"<p>{postManHeaderDisplay}</p>");
                //}


            });

            app.Run();
        }
    }
}