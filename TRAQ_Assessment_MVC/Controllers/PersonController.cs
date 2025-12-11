using AutoMapper;
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
    private readonly IMapper _mapper;

    public PersonController(IPersonService personService, IAccountService accountService, IMapper mapper)
    {
        this._personService = personService;
        this._accountService = accountService;
        this._mapper = mapper;
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
    public async Task<IActionResult> Update(int id)
    {
        return View(_mapper.Map<CreatePersonViewModel>(await _personService.GetViewModel(id)));
    }

    [HttpPatch]
    public async Task<IActionResult> Update(CreatePersonViewModel model)
    {
        await _personService.Post(model);
        return RedirectToAction(controllerName: "Person", actionName: "Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePersonViewModel model)
    {
        await _personService.Post(model);
        return RedirectToAction(controllerName: "Person", actionName: "Index");
    }

}
