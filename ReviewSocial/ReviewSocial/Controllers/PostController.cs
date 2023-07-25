using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReviewSocial.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Hosting;
using ReviewSocial.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Linq;

namespace ReviewSocial.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string view = "~/Views/Admin/PostManagement/";

        public PostController(IPostRepository postRepository, 
            ICategoryRepository categoryRepository, 
            IHttpContextAccessor contextAccessor, 
            IWebHostEnvironment webHostEnvironment)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        // Trang chủ danh sách bài viết của 1 category
        public IActionResult Index(int CategoryId)
        {
            ViewBag.Category = _categoryRepository.GetById(CategoryId);
            ViewBag.Posts =_postRepository.GetAll().Take(3);
            var posts = _postRepository.GetAllByCategoryId(CategoryId);
            return View(posts);
            
        }
        public IActionResult Details(int id)
        {
            var post = _postRepository.GetPostAndUserAndCategoryById(id);
            post.View = post.View + 1;
            _postRepository.Update(post);
            return View(post);
        }


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.Categories = _categoryRepository.GetAll();
        //    return View(view + "CreateAndUpdate.cshtml");
        //}

        //[HttpPost]
        //public IActionResult Create(Post post, IFormFile thumbnailFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        post.CreatedDate = DateTime.UtcNow;
        //        post.UpdatedDate = DateTime.UtcNow;
        //        post.UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
        //        post.View = 0;
        //        post.TotalReport = 0;
        //        post.Status = true;
        //        post.Like = 0;
        //        //post.Thumbnail = UploadFile(thumbnailFile);
        //        _postRepository.Create(post);
        //        return RedirectToRoute("admin/post");
        //    }

        //    ViewBag.Categories = _categoryRepository.GetAll();
        //    return View(view + "CreateAndUpdate.cshtml");
        //}

        // hàm thêm bài viết ở user
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
        
        [HttpPost]
        public IActionResult Create( Post post ,IFormFile file)
        {
            //hàm check trùng
            //if (_postRepository.CheckExitsTitle(post.Title))
            //{
            //    return Ok(new
            //    {
            //        message = "Tiêu đề đã tồn tại"
            //    });
            //}

            try
            {
                post.CreatedDate = DateTime.UtcNow;
                post.UpdatedDate = DateTime.UtcNow;
                post.UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
                post.View = 0;
                post.TotalReport = 0;
                post.Status = true;
                post.Like = 0;
                post.Thumbnail = UploadFile(file);
                _postRepository.Create(post);
                return Ok(post);
            }
            catch
            {
                return BadRequest();
            }
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
        
        //sửa bài viết user
        [HttpPost]
        public Post Update(Post post, IFormFile file)
        {
            var postFound = _postRepository.GetById(post.Id);
            postFound.Title = post.Title;
            postFound.Content = post.Content;
            if (file != null)
            {
                postFound.Thumbnail = UploadFile(file);
            }
            postFound.CategoryId = post.CategoryId;
            postFound.UpdatedDate = DateTime.Now;
            _postRepository.Update(postFound);
            return postFound;
        }
        
        [HttpPost]
        public int Delete(int id)
        {
            var postFound = _postRepository.GetById(id);
            _postRepository.Delete(postFound);
            return id;
        }

        // hàm update view
        [HttpPost]
        public IActionResult UpdateView (int id)
        {
            var post = _postRepository.GetById(id);
            post.View = post.View + 1;
            _postRepository.Update(post);
            return Ok();
        }

        // Hàm ẩn bài viết
        [HttpPost]
        public IActionResult HidenPost(int id)
        {
            var post = _postRepository.GetById(id);
            post.Status = false;
            _postRepository.Update(post);
            return Ok();
        }

        // hàm tìm kiếm ở trang chủ
        [HttpGet]
        public IActionResult Search(string keyword, int? subCategoryId, DateTime? from, DateTime? to)
        {
            from = from?.Add(new TimeSpan(00, 00, 00));
            to = to?.Add(new TimeSpan(23, 59, 59));

            var posts = _postRepository.Search(keyword, subCategoryId, from, to);

            ViewBag.Posts = _postRepository.GetAll().OrderByDescending(p => p.View).Take(3);
            ViewBag.Categories = _categoryRepository.GetAll();

            ViewBag.Keyword = keyword;
            ViewBag.CategoryId = subCategoryId;
            ViewBag.From = from;
            ViewBag.To = to;
            return View(posts);
        }
    }
}
