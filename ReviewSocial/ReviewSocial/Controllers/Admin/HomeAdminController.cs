using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    [Route("admin")]
    public class HomeAdminController : Controller
    {
        private readonly string view = "~/Views/Admin/HomeAdmin/";

        [Route("")]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml");
        }
    }
}
