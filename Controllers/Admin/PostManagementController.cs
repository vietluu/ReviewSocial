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
using System.Threading.Tasks;

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

     
             public async Task<string> UploadFile(IFormFile file)
        {

           if(file != null){

                var fileName = DateTime.UtcNow.Ticks.ToString() + Path.GetExtension(Path.GetFileName(file.FileName));
                Console.WriteLine(fileName);
                var filePath = Path.Combine("wwwroot", "img", fileName);
            
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            
            return $"img/{fileName}";
           }
           else{
                return "";
            }
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            return View(view + "CreateAndUpdate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile thumbnailFile)
        {
            Console.WriteLine(thumbnailFile.FileName);
            var image = await UploadFile(thumbnailFile);

            var item = new Post
            {
                CreatedDate = DateTime.UtcNow,
                UserId = int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid)),
                CategoryId = post.CategoryId,
                Content = post.Content ?? "",
                Title = post.Title ?? "",
                TotalReport = 0,
                View = 0,
                Thumbnail = image,
            };

            _postRepository.Create(item);
                return RedirectToRoute("admin/post");
            

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
                // post.Thumbnail = (thumbnailFile != null && thumbnailFile.Length > 0) ? UploadFile(thumbnailFile) : post.Thumbnail;
                // post.UpdatedDate = DateTime.UtcNow;
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
