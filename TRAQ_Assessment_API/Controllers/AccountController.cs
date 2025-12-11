using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    public IAccountRepository _repo { get; set; }
    public IMapper _mapper { get; set; }

    public AccountController(IAccountRepository repo, IMapper mapper)
    {
        this._repo = repo;
        this._mapper = mapper;
    }

    [HttpGet("list/{id}")]
    public async Task<List<AccountDto>> GetList(int id)
    {
        return _mapper.Map<List<AccountDto>>(await _repo.GetList(id));
    }

    [HttpGet("{id}")]
    public async Task<AccountDto> GetId(int id)
    {
        return _mapper.Map<AccountDto>(await _repo.GetById(id));
    }

    [HttpPost]
    public async Task<AccountDto> Post(AccountDto model)
    {
        return _mapper.Map<AccountDto>(await _repo.Post(_mapper.Map<Account>(model)));
    }

    [HttpPatch]
    public async Task<AccountDto> Patch(AccountDto model)
    {
        return _mapper.Map<AccountDto>(await _repo.Update(_mapper.Map<Account>(model)));
    }
}

