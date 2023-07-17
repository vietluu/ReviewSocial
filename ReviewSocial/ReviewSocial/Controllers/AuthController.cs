using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using ReviewSocial.Repositories.Impl;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace ReviewSocial.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly string view = "~/Views/Auth";

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email == null && password == null)
            {
                TempData["Message"] = "Vui lòng nhập đầy đủ thông tin!";
                return RedirectToRoute("login");
            }
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                TempData["Message"] = "Tài khoản không tồn tại!";
                return RedirectToRoute("login");
            }
            if (user.Password != password)
            {
                TempData["Message"] = "Thông tin tài khoản hoặc mật khẩu không chính xác!";
                return RedirectToRoute("login");
            }
            await setDataToClaim(user);
            HttpContext.Session.SetString("id", user.Id.ToString());
            HttpContext.Session.SetString("email", user.Email);
            HttpContext.Session.SetString("username", user.Username);
            if (user.Role == "Admin")
            {
                return RedirectToRoute("admin");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task setDataToClaim(User user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToRoute("login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            //if (user.Email == null || user.Username == null || user.Password== null || user.)
            //{
            //    tempdata["message"] = "vui lòng nhập đầy đủ thông tin!";
            //    return redirecttoroute("login");
            //}
            
            user.CreatedDate = DateTime.UtcNow;
            user.Role = "User";
            user.Status = true;
            _userRepository.Create(user);

            return RedirectToAction("Login", "Auth");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
