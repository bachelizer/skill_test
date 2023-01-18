using Microsoft.AspNetCore.Mvc;
using skill_test.Interfaces;

namespace skill_test.Controllers;

public class LoginController : Controller
{
    private readonly ILogin _loginService;

    public LoginController(ILogin loginService)
    {
        _loginService = loginService;
    }

    public IActionResult LoginPage()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        var adminAccount = _loginService.AuthSuperAdmin(email, password);
        if (adminAccount) return RedirectToAction("Index", "User");

        var userAccount = await _loginService.AuthUser(email, password);
        if (userAccount is not null)  return RedirectToAction("Index", "Home", userAccount);
      
        return View("LoginPage");

    }
}