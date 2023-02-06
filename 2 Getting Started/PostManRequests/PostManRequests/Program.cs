using Microsoft.Extensions.Primitives;

namespace PostManRequests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            ///post man helps to add our customized header key value pair 
            app.Run(async (HttpContext context) =>
            {
                context.Response.Headers["Content-type"] = "text/html";

                if (context.Request.Headers.ContainsKey("Post-man-created-header"))
                {
                    string displayCreatedHeader = context.Request.Headers["Post-man-created-header"];
                    await context.Response.WriteAsync($"<p>{displayCreatedHeader}</p>");
                }

                ///post request is send with a body in post man that could be read using streamReader
                ///Here body is a stream type

                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync(); // we get the content of the body stored in the form of string and to get the value of certain key it is difficult so we use a built in package and library of microsoft to do so to extract key value pair and store in the form of dictionary ie raw body of string like "firstName=Kunal&age=13&age=23" => ["firstName"] = "kunal" ["age"] = "13" and "23"

                Dictionary<string, StringValues> queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body); // we are storing <string, stringValues> bcoz age is a key having multiple values possible 

                if (queryDictionary.ContainsKey("firstName"))
                {
                    string firstName = queryDictionary["firstName"][0]; // ie first value
                    await context.Response.WriteAsync($"<p>{firstName}</p>");
                }

            });

            app.Run();
        }
    }
}