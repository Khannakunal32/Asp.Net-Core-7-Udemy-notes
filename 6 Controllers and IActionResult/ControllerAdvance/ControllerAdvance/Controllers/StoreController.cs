using Microsoft.AspNetCore.Mvc;

namespace ControllerAdvance.Controllers
{
    public class StoreController : Controller
    {

        [Route("store")]
        public IActionResult OpenStore()
        {
            return Content("Hi you are inside the store now");
        }

        [Route("/kunal")]

        public IActionResult KunalStore()
        {
            return Content($"Hi you are in store wiht id: {Convert.ToInt32(Request.Query["id"])}");
        }

    }
}
