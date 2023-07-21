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
using System.Collections.Generic;

namespace ReviewSocial.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICommentRepository _comment;
        private readonly string view = "~/Views/Admin/PostManagement/";

        public PostController(IPostRepository postRepository, 
            ICategoryRepository categoryRepository, 
            IHttpContextAccessor contextAccessor, 
            IWebHostEnvironment webHostEnvironment,
            ICommentRepository comment)
        {
            _postRepository = postRepository;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
            _comment = comment;
        }

        // Trang chủ danh sách bài viết của 1 category
        public IActionResult Index(int id)
        {
            var cate = _categoryRepository.GetAll();
            var post = _postRepository.GetAll();
            return View(new Tuple<IEnumerable<Category>, IEnumerable<Post>>(cate, post));
            
        }
        public IActionResult Details(int id)
        {
            var item = _postRepository.GetById(id);
            item.View += 1;
            _postRepository.Update(item);
            var cmt = _comment.GetByPost(id);
            var post = _postRepository.GetById(id);
            return View(new Tuple<Post, IEnumerable<Comment>>(post, cmt));

            
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
            try
            {
                post.CreatedDate = DateTime.UtcNow;
                // post.UpdatedDate = DateTime.UtcNow;
                post.UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));
                post.View = 0;
                post.TotalReport = 0;
                post.Status = true;
                // post.Like = 0;
                post.Thumbnail = UploadFile(file);
                _postRepository.Create(post);
                return Ok(post);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Comment(Comment comment)
        {
            try
            {
                var item = new Comment();
                item.CreatedDate = DateTime.UtcNow;
                // item.UpdatedDate = DateTime.UtcNow;
                item.UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid));

                item.PostsId = comment.PostsId;
                item.Content = comment.Content;
                // post.Like = 0;

                _comment.Create(item);
                return Ok();;
            }
            catch
            {
                return BadRequest();
            }
        }
          [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _comment.GetById(id);
                if (item == null)
                {
                    return NotFound();
                }

                _comment.Delete(item);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult UpdateCmt(string content ,int id){
            try
            {
                Console.WriteLine(id);
                var item = _comment.GetById(id);
                item.Content = content;
                Console.WriteLine(item);
                _comment.Update(item);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        

    }
}
