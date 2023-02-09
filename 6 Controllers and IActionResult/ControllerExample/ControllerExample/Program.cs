namespace ControllerExample
{
    /// <summary>
    /// first we create a folder controller and add a empty controller into folder 
    /// 1. Go to Home controller and see the defination till method 1
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // we need to add the service addControllers to use the controller from another file\
            ///set 1 
            ///builder.Services.AddTransient<HomeController>();
            ///but here we need to define for every controlelr to use the service
            ///
            /// so to get the builder to add the service of all the controller we use addController

            builder.Services.AddControllers();

            var app = builder.Build();

            /// set 1 to create nad define the endpoint of a controller first define rout and set the endpoins to endpoints.MapController
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();

            //});

            ///set 2 we use the app.mapController that automatically handles the routes and endpoint of the contorller 
            app.MapControllers();


            app.Run();
        }
    }
}