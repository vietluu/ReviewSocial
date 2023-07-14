using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    [Route("admin")]
    public class CategoryManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/CategoryManagement/";

        [Route("category")]
        public IActionResult Index()
        {
            return View(view+ "Index.cshtml");
        }
    }
}
