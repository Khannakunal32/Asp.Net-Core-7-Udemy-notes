using ControllerExample.Properties.Controller.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Properties.Controller
{
    /// this is the empty controller template
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    // to create a controller we use create a public class and last name should end with Home"Controller" so that asp.net recognize it as controller or we can define [controller] above the class instead or we can use both

    [Controller] //optional if we dont write function name with Controller at end
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller // the class of controller have a property of content to use 
    {

        // we create our routes below with the following method
        //here we define the route name and the below is the method to run if the route matches the name go to defination of route and see the argument 
        [Route("method1")]
        // the belo2w is the action method
        public string action1()
        {
            return "Hello from action1";
        }


        ///We can add multiple route names to a single action method
        [Route("method2")]
        [Route("/")]
        public string action2()
        {
            return "Hello from action2";
        }


        [Route("Contact-us/{mobile:regex(^\\d{{10}}$)}")] //the regex expression says that \d is the digit only and {10} means only 10 digits allowed

        public string Contact()
        {
            return $"Hello from Contact";
        }


        [Route("Index")]
        public ContentResult Index()
        {
            return new ContentResult { Content = "<h1>Hello from Index</h1>", ContentType = "text/html" };
        }

        [Route("ShorterIndex")]
        public ContentResult ShorterIndex()
        {
            //we can use Content isntead of content result by ysing the interface of Controller ie a part of microsoft.aspnetCore.mvc for shortere form without using object of content result
            return Content("<h1>Hellow from ShorterIndex</h1>", "text/html"); // go and see that content is returnnig a contentresult type and is int th micros..aspnetcore.mvc name space ie we have inherited above after namespace
        }

        [Route("JsonExample1")]
        public string JsonAction1()
        {
            return "{\"key\": \"value\"}"; // not a good way to send json objects
        }

        [Route("JsonExample2")]

        public JsonResult JsonAction2()
        {

            // we create a new peroson object and pass it to jsonResult
            Person person = new Person
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                age = 1,
            };

            // return new JsonResult(person); // this is a method for creating with new object
            return Json(person); // a short method of the above and is the same return type see defination
        }
    }
}
