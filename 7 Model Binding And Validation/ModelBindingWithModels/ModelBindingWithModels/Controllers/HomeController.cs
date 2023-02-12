using Microsoft.AspNetCore.Mvc;
using ModelBindingWithModels.Models;

namespace ModelBindingWithModels.Controllers
{
    public class HomeController : Controller
    {
        //url: /bookstore/10/false?bookid=2&isloggedin=true
        [Route("/bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        { // put a debugger here and run /bookstore/10/false?bookid=2&isloggedin=true&author=kunal
          // the above query bookid = 2 (query), isloggein = false (route) bookobject bookid = 10 (route)
          // but bookobject author = kunal (query) as we have not defined [from...] so it takes anywhere it gets 
            if (!bookid.HasValue)
            {
                Response.WriteAsync("Book id key not provided");
                return new StatusCodeResult(400);
            }


            if (bookid <= 0)
            {

                Response.WriteAsync("Book ID contains no ID");
                return new BadRequestResult();
            }

            int? bookId = bookid;
            if (bookId <= 0 || bookId > 1000)
            {

                return BadRequest("Book ID not in range of 0 to 1000");
            }

            if (!isloggedin.HasValue || isloggedin != true)
            {
                return NotFound("User not authorised/ User not logged In");


            }

            //return new RedirectToActionResult("OpenStore", "Store", new { }, true);
            return Content($"Book id: {bookid}, Book: {book}", "text/html");
        }
    }
}
