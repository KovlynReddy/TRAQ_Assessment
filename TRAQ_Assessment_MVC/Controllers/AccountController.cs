using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;

namespace TRAQ_Assessment_MVC.Controllers;

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
}