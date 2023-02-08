using Microsoft.Extensions.FileProviders;

namespace RoutingThree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ///Note extra we can create guid from the tools in visual studio above
            ///Note creating a wwwroot folder in the root of project inside solution let the browser read any file (txt, pdf, img, mp4, mp3 directly ....etc)
            ///just directly tpe like localhost/read.txt which is in wwwroot
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseStaticFiles(); // this line helps to enable wwwroot folder to read the static files and excess directly
            /// we can also change the name of the wwwroot folder to something else 
            //var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
            //{
            //    WebRootPath = "myroot"
            //});
            /// we can create the folder myroot and use it to store the direct static files instead of wwwroot
            /// 

            //Note we can add another same static folder as the above method only takes one arguement and sets only one folder as like wwwroot so for multiple folder can be set up like

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                  //builder.Environment.ContentRootPath + "\\wwwrootAlternative"
                  /// Here builder.Environment.ContentRootPath gives tthe current working 
                  /// directory like C:\Users\Kunal\Desktop\projects\Asp.Net Core 7 (.Net 7) - Udemy\5 Routing\RoutingThree\RoutingThree\RoutingThree.csproj on which we add "\wwwrootAlternative

                  Path.Combine(builder.Environment.ContentRootPath, "wwwrootAlternative")
            )
            });




            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}