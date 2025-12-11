using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : Controller
{
    public ITransactionRepository _repo { get; set; }
    public IMapper _mapper { get; set; }

    public TransactionController(ITransactionRepository repo, IMapper mapper)
    {
        this._repo = repo;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<List<TransactionDto>> GetList()
    {
        return _mapper.Map<List<TransactionDto>>(await _repo.GetList());
    }

    [HttpGet("{id}")]
    public async Task<TransactionDto> GetId(int id)
    {
        return _mapper.Map<TransactionDto>(await _repo.GetById(id));
    }

    [HttpPost]
    public async Task<TransactionDto> Post(TransactionDto model)
    {
        return _mapper.Map<TransactionDto>(await _repo.Post(_mapper.Map<Transaction>(model)));
    }

    [HttpPatch]
    public async Task<TransactionDto> Patch(TransactionDto model)
    {
        return _mapper.Map<TransactionDto>(await _repo.Update(_mapper.Map<Transaction>(model)));
    }
}
