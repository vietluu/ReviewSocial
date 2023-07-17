using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using ReviewSocial.Repositories;

namespace ReviewSocial.Controllers.Admin
{
    public class CategoryManagementController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly string view = "~/Views/Admin/CategoryManagement/";

        public CategoryManagementController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml", _categoryRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                if (CategoryExists(category.Name))
                {
                    return Ok(new
                    {
                        message = "Tên danh mục đã tồn tại"
                    });
                }
                _categoryRepository.Create(category);
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_categoryRepository.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            try
            {
                var categoryExists = _categoryRepository.GetById(id);

                if (categoryExists == null)
                {
                    return NotFound();
                }

                if (category.Name != categoryExists.Name && CategoryExists(category.Name))
                {
                    return Ok(new
                    {
                        message = "Tên nhóm danh mục đã tồn tại"
                    });
                }

                categoryExists.Name = category.Name;
                _categoryRepository.Update(categoryExists);
                return Ok(categoryExists);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _categoryRepository.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                _categoryRepository.Delete(category);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        public bool CategoryExists(string name)
        {
            return _categoryRepository.ExistsByName(name);
        }
    }
}
