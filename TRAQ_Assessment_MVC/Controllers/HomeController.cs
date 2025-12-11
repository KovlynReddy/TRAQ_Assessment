using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TRAQ_Assessment_DLL.Entities;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Models;

namespace TRAQ_Assessment_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewData["Message"] = "Welcome";
        return View();
    }

    [HttpGet]
    public IActionResult About()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Contact()
    {
        ViewBag.Email = "kovlyn.reddy@gmail.com";
        ViewBag.Cell = "(+27) 67 801 7809";
        ViewBag.GitHub = "https://github.com/KovlynReddy";
        ViewBag.LinkedIn = "https://www.linkedin.com/in/kovlyn-reddy-ba4a741a8/";

        return View();
    }
}
