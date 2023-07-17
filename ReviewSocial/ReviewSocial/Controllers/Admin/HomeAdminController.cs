using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        private readonly string view = "~/Views/Admin/HomeAdmin/";

        [HttpGet]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml");
        }
    }
}
