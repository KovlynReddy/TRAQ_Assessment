using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;

namespace TRAQ_Assessment_MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }
    public IActionResult Index()
    {
        return View();
    }
}
