using Microsoft.AspNetCore.Mvc;

namespace ReviewSocial.Controllers.Admin
{
    [Route("admin")]
    public class PostManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/PostManagement/";

        [Route("post")]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml");
        }
    }
}
