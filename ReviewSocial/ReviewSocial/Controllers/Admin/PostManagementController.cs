using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    public class PostManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/PostManagement/";

        public IActionResult Index()
        {
            return View(view + "Index.cshtml");
        }
    }
}
