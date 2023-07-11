using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
