using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    [Route("admin")]
    public class UserManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/UserManagement/";
        [Route("user")]
        public IActionResult Index()
        {
            return View(view+ "Index.cshtml");
        }
    }
}
