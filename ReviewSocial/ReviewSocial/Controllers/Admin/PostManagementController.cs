using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using System.IO;

namespace ReviewSocial.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class PostManagementController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string view = "~/Views/Admin/PostManagement/";

        public PostManagementController(IPostRepository postRepository, ICategoryRepository categoryRepository, IHttpContextAccessor contextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(view + "Index.cshtml", _postRepository.GetAll());
        }

        public string UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Lấy đường dẫn nơi bạn muốn lưu trữ ảnh trên server
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/posts");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(imagePath))
                    Directory.CreateDirectory(imagePath);

                // Tạo tên file duy nhất cho ảnh
                var uniqueFileName = DateTime.UtcNow.Ticks.ToString() + Path.GetExtension(file.FileName);

                // Tạo đường dẫn đầy đủ của file ảnh trên server
                var filePath = Path.Combine(imagePath, uniqueFileName);

                // Lưu ảnh lên server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return uniqueFileName;
            }
            return "";
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(view + "CreateAndUpdate.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Post post, IFormFile thumbnailFile)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.UtcNow;
                post.UpdatedDate = DateTime.UtcNow;
                post.UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
                post.View = 0;
                post.TotalReport = 0;
                post.Status = true;
                post.Like = 0;
                post.Thumbnail = UploadFile(thumbnailFile);
                _postRepository.Create(post);
                return RedirectToRoute("admin/post");
            }

            ViewBag.Categories = _categoryRepository.GetAll();
            return View(view + "CreateAndUpdate.cshtml");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.TitlePage = "Chỉnh sửa bài viết";
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(view + "CreateAndUpdate.cshtml", _postRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(int id, Post post, IFormFile thumbnailFile)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                post.Thumbnail = (thumbnailFile != null && thumbnailFile.Length > 0) ? UploadFile(thumbnailFile) : post.Thumbnail;
                post.UpdatedDate = DateTime.UtcNow;
                _postRepository.Update(post);
                return RedirectToRoute("admin/post");
            }

            ViewBag.Categories = _categoryRepository.GetAll();
            return View(view + "CreateAndUpdate.cshtml");
        }

        [HttpPost]
        public int Delete(int id)
        {
            _postRepository.Delete(_postRepository.GetById(id));
            return id;
        }
    }
}
