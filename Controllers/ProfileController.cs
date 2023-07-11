using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using Microsoft.AspNetCore.Identity;

namespace ReviewSocial.Controllers;
public class ProfileController : Controller{


    public IActionResult Index()
    {
        return View();
    }
}