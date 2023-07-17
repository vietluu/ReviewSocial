using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

        
    }
}
