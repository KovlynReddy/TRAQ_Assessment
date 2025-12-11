using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Account;
using TRAQ_Assessment_MVC.Models.Person;

namespace TRAQ_Assessment_MVC.Controllers;

// [Authorize]
public class AccountController : Controller
{
    private readonly IPersonService _personService;
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;

    public AccountController(IAccountService accountService, IPersonService personService, ITransactionService transactionService)
    {
        this._accountService = accountService;
        this._personService = personService;
        this._transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _personService.GetViewModelList());
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, int holderId)
    {
        // get list of Transaction by person id
        var viewModel = await _accountService.GetViewModel(id);

        viewModel.Transactions = await _transactionService.GetViewModelList(id, holderId);

        viewModel.HolderDetails = await _personService.GetViewModel(holderId);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CreateAccountViewModel model)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountViewModel model)
    {
        return View();
    }
}