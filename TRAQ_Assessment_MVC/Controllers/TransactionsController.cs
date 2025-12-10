using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;

namespace TRAQ_Assessment_MVC.Controllers;

public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService service)
    {
        this._transactionService = service;
    }

    public IActionResult Index()
    {
        return View();
    }
}
