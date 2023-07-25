using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Repositories;

namespace ReviewSocial.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly string view = "~/Views/Admin/HomeAdmin/";
        public HomeAdminController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml",_categoryRepository.GetAll());
        }
    }
}
