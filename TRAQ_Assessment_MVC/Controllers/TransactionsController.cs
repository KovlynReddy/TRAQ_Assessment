using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.Transaction;
using TRAQ_Assessment_MVC.Service;

namespace TRAQ_Assessment_MVC.Controllers;

// [Authorize]
public class TransactionsController : Controller
{
    private readonly ITransactionService _transactionService;
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public TransactionsController(ITransactionService transactionService, IPersonService personService, IMapper mapper)
    {
        this._transactionService = transactionService;
        this._personService = personService;
        this._mapper = mapper;
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
    public async Task<IActionResult> Update(int id, int code)
    {
        var data = await _transactionService.GetViewModel(id);

        return View(_mapper.Map<CreateTransactionViewModel>(data));
    }

    [HttpPost]
    public async Task<IActionResult> Update(CreateTransactionViewModel model)
    {
        await _transactionService.Update(model);
        return RedirectToAction(controllerName: "Person", actionName: "Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        return View(new CreateTransactionViewModel() { Account_Code = id, Transaction_Date = DateTime.Now, Capture_Date = DateTime.Now });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionViewModel model)
    {
        await _transactionService.Post(model);
        return RedirectToAction(controllerName: "Person", actionName: "Index");
    }
}
