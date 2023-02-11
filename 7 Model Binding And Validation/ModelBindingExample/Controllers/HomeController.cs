using Microsoft.AspNetCore.Mvc;

namespace ModelBindingExample.Controllers
{
    public class HomeController : Controller
    {

        /// url: /book-without-binding?bookid=2&isloggedin=true
        [Route("/book-without-binding")]
        public IActionResult Book()
        {

            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.WriteAsync("Book id key not provided");
                return new StatusCodeResult(400);
            }


            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {

                Response.WriteAsync("Book ID contains no ID");
                return new BadRequestResult();
            }

            int bookId = Convert.ToInt32(Request.Query["bookid"]);

            if (bookId <= 0 || bookId > 1000)
            {

                return BadRequest("Book ID not in range of 0 to 1000");
            }

            if (!Request.Query.ContainsKey("isLoggedIn") || Request.Query["isLoggedIn"] != "true")
            {
                return NotFound("User not authorised/ User not logged In");


            }

            return new RedirectToActionResult("OpenStore", "Store", new { }, true);

        }
        /// url: /book-with-binding?bookid=2&isloggedin=true
        [Route("/book-with-binding/{bookid}/{isloggedin?}")]
        // in model binding concept we passs the value of query String parameters -> routes data -> request body -> form fields in the parameter and argument of the below function and we dont need to write big lines like Reqest.query.containskey("bookid") we can directly write bookid by model binding


        /// Note increase in priority is like query String parameters -> routes data -> request body -> form fields
        /// if same name of route data and query string parameter then value of route data will be set as more priority
        public IActionResult bookWithBinding(int? bookid, bool? isloggedin) //book id defined
        {

            //if (!Request.Query.ContainsKey("bookid"))
            if (!bookid.HasValue) // instead of full above big line we can write it short
            {
                Response.WriteAsync("Book id key not provided");
                return new StatusCodeResult(400);
            }


            //if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            if (bookid <= 0)
            {

                Response.WriteAsync("Book ID contains no ID");
                return new BadRequestResult();
            }

            //int bookId = Convert.ToInt32(Request.Query["bookid"]);
            int? bookId = bookid;
            if (bookId <= 0 || bookId > 1000)
            {

                return BadRequest("Book ID not in range of 0 to 1000");
            }

            //if (!Request.Query.ContainsKey("isLoggedIn") || Request.Query["isLoggedIn"] != "true")
            if (!isloggedin.HasValue || isloggedin != true)
            {
                return NotFound("User not authorised/ User not logged In");


            }

            return new RedirectToActionResult("OpenStore", "Store", new { }, true);

        }


        /// url: /book-with-binding/3/false?bookid=2&isloggedin=true
        [Route("/book-with-binding-using-from/{bookid}/{isloggedin?}")]

        /// when using [FromRoute] model binding will take parameter as route values /{}
        //public IActionResult bookWithBindingUsingFrom([FromRoute] int? bookid, bool? isloggedin)

        /// when using [FromQuery] model binding will take parameter as query values ?xyz=
        //public IActionResult bookWithBindingUsingFrom([FromQuery] int? bookid, bool? isloggedin)

        /// when nothing is used model binding will take the priority ie route in this case
        public IActionResult bookWithBindingUsingFrom(int? bookid, bool? isloggedin)

        {

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

            return new RedirectToActionResult("OpenStore", "Store", new { }, true);

        }
    }
}
