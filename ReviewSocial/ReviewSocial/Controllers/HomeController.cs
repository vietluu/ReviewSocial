using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReviewSocial.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ReviewSocial.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

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

        public IActionResult Index()
        {
            var cate = _cate.GetAll();
            var post = _post.GetAll();
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
           try{ // lưu ảnh lên server
                if (HttpContext.Session.GetString("id")!= null)
                {
                    var imagePath = "";
                    if (file != null)
                    {
                        imagePath = await _post.UploadFile(file);
                    }
                        DateTime now = DateTime.Now;  
                        var item = new Post
                        {
                            CategoryId = post.CategoryId,
                            Content = post.Content ?? "",
                            CreatedDate = now,
                            // Like = 0,
                            Thumbnail = imagePath,
                            Title = post.Title ?? "",
                            UserId = Convert.ToInt32(HttpContext.Session.GetString("id")),
                            TotalReport = 0,
                            View = 0
                        };

                        _post.Create(item);


                        return Ok();
                    
                }
                else{
                    return Forbid();
                }
            }
            catch{
                return BadRequest();
            }



        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _post.GetById(id);
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

    }
}
