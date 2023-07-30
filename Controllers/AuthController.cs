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
using System.Text.RegularExpressions;

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
            ClaimsPrincipal claimUser = HttpContext.User;
            // _logger.LogInformation("This is my string: " + claimUser.Identity.IsAuthenticated, "");
            if (claimUser.Identity.IsAuthenticated)
            {
                string role = claimUser.FindFirstValue(ClaimTypes.Role);
                if (role == "user")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToRoute("admin");
                }
            }
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email == null && password == null)
            {
                //ViewBag.Message = "Vui lòng nhập đầy đủ thông tin!";
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
            if (user.Avatar != null)
                HttpContext.Session.SetString("avatar", user.Avatar);
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
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"];

            }
            return View();
        }

        //[HttpPost]
        //public IActionResult Register(User user)
        //{
        //    if (userModel.Email == null || userModel.Username == null || userModel.Password == null || userModel.RePassword == null)
        //    {
        //        TempData["message"] = "Vui lòng nhập đầy đủ thông tin!";
        //        return RedirectToRoute("register");
        //    }
        //    var checkemail = _userRepository.GetUserByEmail(userModel.Email);
        //    if(userModel.Email == checkemail.Email)
        //    {
        //        TempData["message"] = "Email đã tồn tại!";
        //        return RedirectToRoute("register");
        //    }

        //    //var user = new User
        //    //{
        //    //    Email= userModel.Email,
        //    //    Username= userModel.Username,
        //    //    Password= userModel.Password,
        //    //    CreatedDate = DateTime.UtcNow,
        //    //    Role = "User",
        //    //    Status = true
        //    //};
        //    userModel.CreatedDate = DateTime.UtcNow;
        //    userModel.Role = "User";
        //    userModel.Status = true;
        //    _userRepository.Create(user);

        //    return RedirectToAction("Login", "Auth");
        //}
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Email == null || user.Username == null || user.Password == null || user.RePassword == null)
            {
                TempData["message"] = "Vui lòng nhập đầy đủ thông tin!";
                return RedirectToRoute("register");
            }
            var checkemail = _userRepository.GetUserByEmail(user.Email);
            if (checkemail != null)
            {
                TempData["message"] = "Email đã tồn tại!";
                return RedirectToRoute("register");
            }
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            if (!Regex.IsMatch(user.Password, passwordPattern))
            {
                TempData["message"] = "Mật khẩu phải có độ dài ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt!";
                return RedirectToRoute("register");

            }
            if (user.Password != user.RePassword)
            {
                TempData["message"] = "Mật khẩu nhập lại không khớp!";
                return RedirectToRoute("register");
            }
            user.CreatedDate = DateTime.UtcNow;
            user.Role = "User";
            user.Status = true;
            user.Avatar = "/avatar.jpg";
            _userRepository.Create(user);

            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(string oldPassword, string ReNewPassword, string newPassword)
        {
            User user = _userRepository.GetUserByEmailAndPassword(HttpContext.Session.GetString("email"), oldPassword);

            if (user == null)
            {
                ViewBag.Error = "Mật khẩu cũ không đúng";
                return View();
            }
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            if (!Regex.IsMatch(newPassword, passwordPattern))
            {
                ViewBag.Error = "Mật khẩu phải có độ dài ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt!"; ;
                return View();

            }
            if (!newPassword.Equals(ReNewPassword))
            {
                ViewBag.Error = "Mật khẩu nhập lại không khớp";
                return View();
            }
            user.Password = ReNewPassword;
            _userRepository.Update(user);
            ViewBag.Result = "Đổi mật khẩu thành công";

            return View();
        }
    }
}
