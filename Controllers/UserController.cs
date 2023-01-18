using Microsoft.AspNetCore.Mvc;
using skill_test.Interfaces;
using skill_test.Models.User;

namespace skill_test.Controllers;

public class UserController : Controller
{
    private readonly IUser _userService;
    private readonly ISmtp _smtpService;

    public UserController(IUser userService, ISmtp smtpService)
    {
        _userService = userService;
        _smtpService = smtpService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userService.List();
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(User userData)
    {
        try
        {
            if (userData == null) return BadRequest();
            await _userService.Create(userData);
            _smtpService.SendMail(userData.LastName, userData.Email);
        }
        catch (Exception)
        {
            throw;
        }
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(string Id)
    {
        var user = await _userService.View(Id);
        if (user == null) return NotFound();
        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Update(User userData)
    {
        try
        {
            await _userService.Update(userData);
        }
        catch (Exception)
        {
            throw;
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Destroy(string Id)
    {
        try
        {
            var user = await _userService.View(Id);
            if (user == null) return NotFound();
            await _userService.Destroy(Id);
        }
        catch (Exception)
        {
            throw;
        }
        return RedirectToAction("Index");
    }
}