using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using System.IO;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ReviewSocial.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IHttpContextAccessor contextAccessor, IUserRepository userRepository, IPostRepository postRepository, IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> ProfileAsync()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToRoute("login");
            }
            return View(_postRepository.GetByUser(int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Sid))));
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var userExists = _userRepository.GetUserByEmail(HttpContext.Session.GetString("email"));
            return View(userExists);
        }

        [HttpPost]
        public IActionResult EditProfile(User user, IFormFile imageAvatarFile)
        {
            var userExists = _userRepository.GetUserByEmail(HttpContext.Session.GetString("email"));

            if (imageAvatarFile != null && imageAvatarFile.Length > 0)
            {
                // Lấy đường dẫn nơi bạn muốn lưu trữ ảnh trên server
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "img");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }

                // Tạo tên file duy nhất cho ảnh
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageAvatarFile.FileName;

                // Tạo đường dẫn đầy đủ của file ảnh trên server
                var filePath = Path.Combine(imagePath, uniqueFileName);

                // Lưu ảnh lên server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageAvatarFile.CopyTo(fileStream);
                }
                userExists.Avatar = uniqueFileName;
            }
            userExists.Username = user.Username;
            _userRepository.Update(userExists);
            HttpContext.Session.SetString("username", userExists.Username);
            HttpContext.Session.SetString("avatar", userExists.Avatar);
            return View(userExists);
        }
    }
}
