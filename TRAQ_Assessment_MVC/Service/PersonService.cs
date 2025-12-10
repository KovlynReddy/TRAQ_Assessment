using TRAQ_Assessment_DLL.Constants;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service;

public class PersonService : IPersonService
{
    private readonly BaseClient<PersonDto> _client;

    public PersonService()
    {
        this._client = new BaseClient<PersonDto>(UrlConstants.User);
    }

    public async Task<List<PersonDto>> GetList()
    {
        return await _client.GetList();
    }

    public async Task<PersonDto> GetById(string id)
    {
        return await _client.GetById(id);
    }

    public async Task<PersonDto> Post(CreateUserViewModel model)
    {
        var dto = new PersonDto() { };

        return await _client.PostJsonAsync(dto);
    }

    public async Task<PersonDto> UpdateUser(CreateUserViewModel model)
    {
        var dto = new PersonDto() { };

        return await _client.PatchJsonSync(dto);
    }
}
