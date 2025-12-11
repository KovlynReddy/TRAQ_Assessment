using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Person;

namespace TRAQ_Assessment_MVC.Controllers;

// [Authorize]
public class PersonController : Controller
{
    private readonly IPersonService _personService;
    private readonly IAccountService _accountService;

    public PersonController(IPersonService personService, IAccountService accountService)
    {
        this._personService = personService;
        this._accountService = accountService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _personService.GetViewModelList());
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        // get list of Accounts by person id
        var viewModel = await _personService.GetViewModel(id);

        viewModel.Accounts = await _accountService.GetViewModelList(id);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CreatePersonViewModel model)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonViewModel model)
    {
        return View();
    }

}
