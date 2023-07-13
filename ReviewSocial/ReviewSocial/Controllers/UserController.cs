using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
