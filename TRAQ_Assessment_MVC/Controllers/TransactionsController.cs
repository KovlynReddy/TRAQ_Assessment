using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Service;

namespace TRAQ_Assessment_MVC.Controllers;

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
}
