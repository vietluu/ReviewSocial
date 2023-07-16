using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    public class UserManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/UserManagement/";

        [HttpGet]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml");
        }
    }
}
