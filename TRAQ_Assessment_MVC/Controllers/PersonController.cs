using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;

namespace TRAQ_Assessment_MVC.Controllers;

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
}
