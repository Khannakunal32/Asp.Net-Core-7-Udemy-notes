using Microsoft.AspNetCore.Mvc;

namespace ControllerAdvance.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/show-static-virtual")]
        public VirtualFileResult ShowStaticFile()
        {
            // if a file present in the root folder that is wwwroot we can send that file using virtualFileResult 

            /// long format, we create an object of virtual file resutl
            //return new VirtualFileResult("/1 res.PNG", "image/png");

            /// short format
            return File("/1 res.PNG", "image/png");
        }

        // if the file is not present in wwwroot folder we can use physicalFileResult

        [Route("/show-static-physical")]

        public PhysicalFileResult ShowPhysicalFile()
        {

            ///long format 
            //return new PhysicalFileResult(@"C:\Users\Kunal\Desktop\college\Kunal Khanna Project Snippets.pdf", "application/pdf");

            /// short format
            return PhysicalFile(@"C:\Users\Kunal\Desktop\college\Kunal Khanna Project Snippets.pdf", "application/pdf");
        }

        // when a part of file or byte[] or encryption is used to send a file from other data source has to be sent as a response then we use FileContentResult

        [Route("/show-static-byte")]

        public FileContentResult ShowStaticByteFile()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Kunal\Desktop\college\Kunal Khanna Project Snippets.pdf");

            ///long format
            //return new FileContentResult(bytes, "application/pdf");

            /// short format file is overloaded according to the arguments so for string it works as virtual and with byte it works as fileContentResult
            return File(bytes, "application/pdf");
        }


        /// Book id below 
        [Route("/book")]


        public IActionResult book() // we use iAction result as the return type of our method is both content type and file type os IAction will take accordingly
        {

            //book id key should be present
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400; // means bad request 
                return Content("Book id key not provided");
            }

            // book id can'g be Empty or NULL
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book ID contains no ID");
            }

            // book id should be between 1 to 1000
            int bookId = Convert.ToInt32(Request.Query["bookid"]);

            if (bookId <= 0 || bookId > 1000)
            {
                return Content("Book ID not in range of 0 to 1000");
            }

            // user must be logged in
            if (!Request.Query.ContainsKey("isLoggedIn") || Request.Query["isLoggedIn"] != "true")
            {
                Response.StatusCode = 400;
                return Content("User not authorised/ User not logged In");
            }

            //Content($"<h1>User authorised! <br> Book id: {Request.Query["bookid"]} <h1>", "text/html");

            // note above we cannot return a different return type other than content so we can send different return types using i action

            return File("/1 res.PNG", "image/png");
        }



        /// Book id below 
        [Route("/bookStore")]


        public IActionResult bookStore() // we use iAction result as the return type of our method is both content type and file type os IAction will take accordingly
        {

            //book id key should be present
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.WriteAsync("Book id key not provided");
                return new StatusCodeResult(400);  // shorter form of response.statusCode = 400;
            }

            // book id can'g be Empty or NULL
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {

                Response.WriteAsync("Book ID contains no ID");
                return new BadRequestResult(); // even shorter technique for 400 error
            }

            // book id should be between 1 to 1000
            int bookId = Convert.ToInt32(Request.Query["bookid"]);

            if (bookId <= 0 || bookId > 1000)
            {

                return BadRequest("Book ID not in range of 0 to 1000"); // even shorter then above lol
            }

            // user must be logged in
            if (!Request.Query.ContainsKey("isLoggedIn") || Request.Query["isLoggedIn"] != "true")
            {
                return NotFound("User not authorised/ User not logged In"); // this is for error 404

                /// or we could use
                /// return Unauthorized("User not authorised/ User not logged In");
            }

            //Content($"<h1>User authorised! <br> Book id: {Request.Query["bookid"]} <h1>", "text/html");

            // note above we cannot return a different return type other than content so we can send different return types using i action

            /// RedirecttoActionresult take us to the differnet route with status code 302 ie found
            //return new RedirectToActionResult("OpenStore", "Store", new { });

            return new RedirectToActionResult("OpenStore", "Store", new { }, true); // the true here is optional and chages the status code ie 301 moved permannently that helps search engines and browser to remeber that the code page is moved permamnently to other route link. stop supporting the previous route 301
        }

        [Route("/redirect")]

        public IActionResult RedirectExample()
        {
            if (!Request.Query.ContainsKey("select"))
            {
                return Content("Please enter the select key in query");
            }

            int num = Convert.ToInt32(Request.Query["select"]);

            if (num == 1)
            {
                return new LocalRedirectResult("/store", false); // redirect the url to internal controller route
            }
            else if (num == 2)
            {
                return new RedirectResult("/store", true); // redirects the url to external page
            }
            else if (num == 3)
            {
                return new RedirectToActionResult("KunalStore", "Store", new { id = 23 }, false); // here we can pass the parameters all so

                //we can use return RedirectToActionPermanent() for by default 301 code
                /// 
            }

            return BadRequest("Enter a valid select value 1-2");
        }

    }
}
