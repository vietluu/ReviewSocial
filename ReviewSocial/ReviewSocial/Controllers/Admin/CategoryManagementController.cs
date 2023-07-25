using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PagedList;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using ReviewSocial.Repositories.Impl;
using System.Globalization;
using System;
using System.Linq;

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
        public IActionResult Index(int page =1, string sortBy = "")

        {
            int PAGE_SIZE = 7;

            var categories= _categoryRepository.GetAll();

            //tổng số trang
            int totalPages = (int)Math.Ceiling((double)categories.Count() / PAGE_SIZE);
            //số trang hiện tại
            int pageNumber;
            if (page > 0)
                pageNumber = page > totalPages ? totalPages : page;
            else
                pageNumber = 1;


            var pagedList = new PagedList<Category>(categories, pageNumber, PAGE_SIZE);

            return View(view + "Index.cshtml", pagedList);
            //return View(view + "Index.cshtml", _categoryRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                //if (category.Name.Length > 10)
                //{
                //    return Ok(new
                //    {
                //        message = "Tên danh mục không vượt quá 10 ký tự"
                //    });
                //}
                //if (CategoryExists(category.Name))
                //{
                //    return Ok(new
                //    {
                //        message = "Tên danh mục đã tồn tại"
                //    });
                //}

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

                //if (category.Name != categoryExists.Name && CategoryExists(category.Name))
                //{
                //    return Ok(new
                //    {
                //        message = "Tên nhóm danh mục đã tồn tại"
                //    });
                //}

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
                // có bài rùi không được xóa
                //if (category.Posts.Count() > 0)
                //{
                //    return Ok(new
                //    {
                //        message = "Bạn không thể xóa danh mục này danh mục này đã có " + category.Posts.Count() + " bài viết!"
                //    });
                //}

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

        // Hàm tìm kiếm
        [HttpGet("admin/category/search")]
        public IActionResult Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Ok(_categoryRepository.GetAll());
            }
            var categories = _categoryRepository.Search(keyword);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }
    }
}
