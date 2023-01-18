using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using skill_test.Models;
using skill_test.Models.User;

namespace skill_test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(User user)
    {
        return View(user);
    }
}
