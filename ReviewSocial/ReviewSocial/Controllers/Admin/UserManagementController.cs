using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Database;
using ReviewSocial.Models;
using ReviewSocial.Repositories;
using System.Text.RegularExpressions;
using System;
using ReviewSocial.Repositories.Impl;

namespace ReviewSocial.Controllers.Admin
{
    public class UserManagementController : Controller
    {
        private readonly string view = "~/Views/Admin/UserManagement/";
        private readonly IUserRepository _userRepository;

        public UserManagementController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(view + "Index.cshtml", _userRepository.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var checkemail = _userRepository.GetUserByEmail(user.Email);
            if (checkemail != null)
            {
                return Ok(new
                {
                    message = "Email đã tồn tại!"
                });
            }
            //string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            //if (!Regex.IsMatch(user.Password, passwordPattern))
            //{
            //    TempData["message"] = "Mật khẩu phải có độ dài ít nhất 8 kí tự, bao gồm chữ hoa, chữ thường, số và kí tự đặc biệt!";
            //    return RedirectToRoute("register");
            //}
            //if (user.Password != user.RePassword)
            //{
            //    TempData["message"] = "Mật khẩu nhập lại không khớp!";
            //    return RedirectToRoute("register");
            //}
            user.CreatedDate = DateTime.Now;
            // user.Role = "User";
            user.Status = true;
            user.LockCount = 0;
            user.LockDate = DateTime.Now;
            _userRepository.Create(user);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Update(int id, [FromBody] User user)
        {
            try
            {
                var userExists = _userRepository.GetById(id);

                if (userExists == null)
                {
                    return NotFound();
                }

                userExists.Email = user.Email;
                if (user.Password != "")
                {
                    userExists.Password = user.Password;
                }
                userExists.Role = user.Role;

                _userRepository.Update(userExists);
                return Ok(userExists);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_userRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                if (user.Status == true)
                {
                    user.Status = false;
                }
                else
                {
                    user.Status = true;
                }
                // có bài rùi không được xóa
                //if (category.Posts.Count() > 0)
                //{
                //    return Ok(new
                //    {
                //        message = "Bạn không thể xóa danh mục này danh mục này đã có " + category.Posts.Count() + " bài viết!"
                //    });
                //}

                _userRepository.Update(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
