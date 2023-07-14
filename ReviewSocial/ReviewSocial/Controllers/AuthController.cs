using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers
{
    [Route("auth")]
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
        private readonly string view = "~/Views/Auth";

        [Route("changepassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
