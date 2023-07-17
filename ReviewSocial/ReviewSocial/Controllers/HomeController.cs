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


namespace ReviewSocial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _post;

        public HomeController(ILogger<HomeController> logger,IPostRepository post)
        {
            _logger = logger;
            _post = post;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<String> Create(Post post, IFormFile file)
        {
             if (!ModelState.IsValid)
    {
        return "false";
    }
        // lưu ảnh lên server
        var imagePath = await _post.UploadFile(file);
            Console.WriteLine("aadd", imagePath);
            DateTime now = DateTime.Now;            // tạo mới mặt hàng
            var item = new Post
            {
                CategoryId = post.CategoryId,
                Content = post.Content,
                CreatedDate = now,
                Like = 0,
                Thumbnail = imagePath,
                Title = post.Title,
                UserId =Convert.ToInt32(HttpContext.Session.GetString("id")),
                TotalReport = 0 ,
                View = 0
        };
       
         _post.Create(item);


        return "hihi";
    
}
        
    }
}
