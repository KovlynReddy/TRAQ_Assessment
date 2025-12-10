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
        return View();
    }
}
