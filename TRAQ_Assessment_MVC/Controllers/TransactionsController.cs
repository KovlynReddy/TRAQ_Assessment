using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.Transaction;

namespace TRAQ_Assessment_MVC.Controllers;

// [Authorize]
public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionService;
    private readonly IPersonService _personService;

    public TransactionsController(ITransactionService transactionService, IPersonService personService)
    {
        this._transactionService = transactionService;
        this._personService = personService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, [FromQuery] int holderId)
    {
        var viewModel = await _transactionService.GetViewModel(id);

        viewModel.HolderDetails = await _personService.GetViewModel(holderId);

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CreateTransactionViewModel model)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionViewModel model)
    {
        return View();
    }
}
