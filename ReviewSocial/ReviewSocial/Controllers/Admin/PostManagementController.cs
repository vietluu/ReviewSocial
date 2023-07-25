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
using PagedList;
using System.Linq;

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
        //hàm hiển thi dữ liệu ra bảng
        public IActionResult Index(int page =1,string sortBy ="")
        {
            ViewBag.Category = _categoryRepository.GetAll();
            int PAGE_SIZE = 10;
           
            var posts = _postRepository.GetAll(sortBy);
          
            //tổng số trang
            int totalPages = (int)Math.Ceiling((double)posts.Count() / PAGE_SIZE);
            //số trang hiện tại
            int pageNumber;
            if (page > 0)
                pageNumber = page > totalPages ? totalPages : page;
            else
                pageNumber = 1;

            
            var pagedList = new PagedList<Post>(posts, pageNumber, PAGE_SIZE);

            return View(view + "Index.cshtml", pagedList);

            //return View(view + "Index.cshtml", _postRepository.GetAll());
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
        // hàm xóa ảnh
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/posts/" + imageName);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
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

                //if (post.Title.Length > 10)
                //{
                //    ViewBag.ErrorTitle = "Tiêu đề không được vượt quá 10 ký tự";
                //    ViewBag.Categories = _categoryRepository.GetAll();
                //    return View(view + "CreateAndUpdate.cshtml");
                //}
                //if (_postRepository.CheckExitsTitle(post.Title))
                //{
                //    ViewBag.ErrorTitle = "Tiêu đề đã tồn tại";
                //    ViewBag.Categories = _categoryRepository.GetAll();
                //    return View(view + "CreateAndUpdate.cshtml");
                //}

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
            return View(view + "CreateAndUpdate.cshtml", _postRepository.GetPostAndUserAndCategoryById(id));
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
                //if(thumbnailFile != null)
                //{
                //    DeleteImage(post.Thumbnail);
                //}

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
            _postRepository.Delete(_postRepository.GetPostAndUserAndCategoryById(id));
            return id;
        }
        // Hàm tìm kiếm 
        public IActionResult Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return Ok(_postRepository.GetAll());
            }
            var posts = _postRepository.Search(keyword);
            if (posts ==null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        public IActionResult GetPostById(int id)
        {
            try
            {
                return Ok(_postRepository.GetById(id));

            }
            catch
            {
                return NotFound();
            }
        }

    }
}
