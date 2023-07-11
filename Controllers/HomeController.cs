using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReviewSocial.Models;
using Microsoft.AspNetCore.Identity;

namespace ReviewSocial.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private readonly SignInManager<User> _signInManager;
    public HomeController(ILogger<HomeController> logger )
    {
        _logger = logger;
        
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

//     [HttpPost]
// public async Task<IActionResult> Login(string email, string Password)
// {
//     if (ModelState.IsValid)
//     {
//         var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
//         if (result.Succeeded)
//         {
//             return RedirectToAction("Index", "Home", new { name = model.Email });
//         }
//     }
    
// }
}
