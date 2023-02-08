using RoutingTwo.CustomConstraints;

namespace RoutingTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Hey builder i want services of AddRouting , please add options in constraint map with the name of chocolateConstraint with the type of my defined class of MyCustomConstraint
            builder.Services.AddRouting(options =>
            {
                options.ConstraintMap.Add("chocolateConstraint", typeof(MyCustomConstraint));
            });
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            ///hey app listing to the routing request and start it
            app.UseRouting();

            ///hey app start the endpoints
            app.UseEndpoints(endpoints =>
            {

                // we are using route constraint id:int? means id is of int type and ? means it's optional
                endpoints.Map("products/details/{id:int?}", async context =>
                {
                    int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
                    await context.Response.WriteAsync($"Products detail - {id}\n");
                });

                // we use '-' in route daily-report as this is good for identifying and seo
                endpoints.Map("daily-report/{reportdate:datetime}", async context =>
                {
                    DateTime dateTime = Convert.ToDateTime(context.Request.RouteValues["datetime"]);
                    await context.Response.WriteAsync($"daily-report - {dateTime.ToShortDateString()}\n");
                });

                // we use guid to create reandom hexadecimal string that foromed with time stamp
                endpoints.Map("random-id/{cityid:guid}", async context =>
                {

                    // the below line says that the string value can't be null using the ! mark at the end in the parse of Guid
                    // note case of guid doesnt matter as it is in the foorm of hexadecimal
                    Guid? readId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);

                    await context.Response.WriteAsync($"random-id - {readId}\n");
                });

                // we can use minlength, maxlength, length, range(a,b), alpha (takes only alphabet);
                endpoints.Map("student/{studentName:minlength(3)=kunal}/{studentGfName:length(3,6)=chhavi}", async context =>
                {
                    string? name = Convert.ToString(context.Request.RouteValues["studentName"]);
                    string? gfName = Convert.ToString(context.Request.RouteValues["studentGfName"]);

                    await context.Response.WriteAsync($"student name - {name} \nstudent gfName = {gfName}\n");
                });


                // we can use minlength, maxlength, length, range(a,b), alpha (takes only alphabet);
                endpoints.Map("bractus/olorio/{chocolate:regex(^(snickers|silk|toblerone|orio|mars|5star)$)}", async context =>
                {
                    string? chocolate = Convert.ToString(context.Request.RouteValues["chocolate"]);

                    await context.Response.WriteAsync($"Chocolate name - {chocolate}\n");
                });

                /// Note its better to use if and else statement to check the condition rather than using regex because it gives us the feedback that what the problem is 
                endpoints.Map("bractus/olorioTwo/{chocolate}", async context =>
                {
                    string? chocolate = Convert.ToString(context.Request.RouteValues["chocolate"]);
                    if (chocolate == "snickers" || chocolate == "silk" || chocolate == "orio" || chocolate == "mars" || chocolate == "5star" || chocolate == "toblerone")
                    {
                        await context.Response.WriteAsync($"Chocolate name - {chocolate}\n");
                    }
                    else
                    {
                        await context.Response.WriteAsync($"Chocolate name - {chocolate} is not allowed\n");
                    }

                });

                /// Using custom Constraint 
                endpoints.Map("bractus/olorioThree/{chocolate:chocolateConstraint}", async context =>
                {
                    string? chocolate = Convert.ToString(context.Request.RouteValues["chocolate"]);

                    await context.Response.WriteAsync($"Chocolate name - {chocolate}\n");
                });
            });

            ///Note take care of endpoint selection order and priority read from the pdf

            app.Run(async (HttpContext context) =>
            {
                string path = context.Request.Path;
                await context.Response.WriteAsync($"No endpoint identified at - {path}");
            });

            app.Run();
        }
    }
}