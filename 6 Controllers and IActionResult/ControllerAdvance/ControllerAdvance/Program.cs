namespace ControllerAdvance
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var app = builder.Build();
            app.UseStaticFiles();

            //app.MapGet("/", () => "Hello World!");

            app.MapControllers();

            app.Run();
        }
    }
}
