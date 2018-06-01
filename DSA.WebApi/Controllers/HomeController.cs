using Microsoft.AspNetCore.Mvc;

namespace SAT.WebApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Json("Web service was started...");
        }
    }
}
