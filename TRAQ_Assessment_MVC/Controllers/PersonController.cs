using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;

namespace TRAQ_Assessment_MVC.Controllers;

public class PersonController : Controller
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        this._personService = personService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _personService.GetViewModelList());
    }
}
