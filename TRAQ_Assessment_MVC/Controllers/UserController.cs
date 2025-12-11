using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // View All
        return View(await _userService.GetList());
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        return View(await _userService.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {     
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserViewModel model)
    { 
        var responmse = await _userService.Post(model);

        return RedirectToAction();
    }
}
