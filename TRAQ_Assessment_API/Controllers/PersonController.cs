using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRAQ_Assessment_API.Data.DBContext;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    public IPersonRepository _repo { get; set; }
    public IMapper _mapper { get; set; }

    public PersonController(IPersonRepository repo, IMapper mapper)
    {
        this._repo = repo;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<List<PersonDto>> GetList()
    {
        return _mapper.Map<List<PersonDto>>(await _repo.GetList());
    }

    [HttpGet("search/{query}")]
    public async Task<List<PersonDto>> Search(string query)
    {
        return _mapper.Map<List<PersonDto>>(await _repo.Search(query));
    }

    [HttpGet("{id}")]
    public async Task<PersonDto> GetId(int id)
    {
        // get list of Accounts

        return _mapper.Map<PersonDto>(await _repo.GetById(id));
    }

    [HttpPost]
    public async Task<PersonDto> Post(PersonDto model)
    {
        return _mapper.Map<PersonDto>(await _repo.Post(_mapper.Map<Person>(model)));
    }

    [HttpPatch]
    public async Task<PersonDto> Patch(PersonDto model)
    {
        return _mapper.Map<PersonDto>(await _repo.Update(_mapper.Map<Person>(model)));
    }
}
 