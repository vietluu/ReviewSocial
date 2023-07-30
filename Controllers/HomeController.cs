using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IO;

namespace ReviewSocial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _post;
        private readonly ICategoryRepository _cate;


        public HomeController(ILogger<HomeController> logger, IPostRepository post, ICategoryRepository cate)
        {
            _logger = logger;
            _post = post;
            _cate = cate;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var cate = _cate.GetAll();
            var post = _post.GetAll();
            return View(new Tuple<IEnumerable<Category>, IEnumerable<Post>>(cate, post));
        }
        [HttpGet]
        public IActionResult Search(string name, int? category)
        {

            IEnumerable<Category> cate = _cate.GetAll();
            IEnumerable<Post> post = null;

            if (category.HasValue)
            {
                post = _post.GetByCategory(category.Value);
            }
            else if (!string.IsNullOrWhiteSpace(name))
            {
                post = _post.GetByTitle(name);
            }
            else
            {
                post = _post.GetAll();
            }


            return View(new Tuple<IEnumerable<Category>, IEnumerable<Post>>(cate, post));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile file)
        {
            try
            {
                if (HttpContext.Session.GetString("id") != null)
                {
                    var imagePath = "";
                    if (file != null)
                    {
                        imagePath = await _post.UploadFile(file);
                    }
                    if (file != null && Path.GetExtension(file.FileName) != "jpg")
                    {
                        return BadRequest();
                    }
                    DateTime now = DateTime.Now;
                    var item = new Post
                    {
                        CategoryId = post.CategoryId,
                        Content = post.Content ?? "",
                        CreatedDate = now,
                        Thumbnail = imagePath,
                        Title = post.Title ?? "",
                        UserId = Convert.ToInt32(HttpContext.Session.GetString("id")),
                        TotalReport = 0,
                        View = 0
                    };

                    _post.Create(item);

                    return Ok();
                }
                else
                {
                    return Forbid();
                }
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

                var item = _post.GetById(id);
                if (Convert.ToInt32(HttpContext.Session.GetString("id")) != item.UserId)
                {
                    return BadRequest();
                }
                if (item == null)
                {
                    return NotFound();
                }

                _post.Delete(item);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCmt(Post post, IFormFile file)
        {
            try
            {
                var item = _post.GetById(post.Id);
                if (item.UserId != Convert.ToInt32(HttpContext.Session.GetString("id")))
                {
                    return BadRequest();
                }
                var imagePath = "";
                if (file != null)
                {
                    imagePath = await _post.UploadFile(file);
                }

                item.CategoryId = post.CategoryId;
                item.Content = post.Content ?? "";
                if (imagePath.Length > 0)
                {
                    item.Thumbnail = imagePath;
                }
                item.Title = post.Title ?? "";
                _post.Update(item);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
