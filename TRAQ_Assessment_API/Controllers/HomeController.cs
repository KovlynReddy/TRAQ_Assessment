using Microsoft.AspNetCore.Mvc;

namespace TRAQ_Assessment_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    public HomeController()
    {
            
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return null;
    }
}
