using AutoMapper;
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
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IPersonService personService, ITransactionService transactionService, IMapper mapper)
    {
        this._accountService = accountService;
        this._personService = personService;
        this._transactionService = transactionService;
        this._mapper = mapper;
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
    public async Task<IActionResult> Update(int id, int code)
    {
        return View(_mapper.Map<CreateAccountViewModel>(await _accountService.GetViewModel(id)));
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CreateAccountViewModel model)
    {
        await _accountService.Update(model);
        return RedirectToAction(controllerName:"Person",actionName:"Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        return View(new CreateAccountViewModel() { Person_Code = id });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountViewModel model)
    {
        await _accountService.Post(model);
        return RedirectToAction(controllerName: "Person", actionName: "Index");
    }
}