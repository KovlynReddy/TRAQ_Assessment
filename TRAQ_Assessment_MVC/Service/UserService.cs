using TRAQ_Assessment_DLL.Constants;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service;

public class UserService : IUserService
{
    private readonly BaseClient<TraqUserDto> _client;

    public UserService()
    {
        this._client = new BaseClient<TraqUserDto>(UrlConstants.User);
    }

    public async Task<List<TraqUserDto>> GetList()
    {
        return await _client.GetList();
    }

    public async Task<TraqUserDto> GetById(string id)
    {
        return await _client.GetById(id);
    }

    public async Task<TraqUserDto> Post(CreateUserViewModel model)
    {
        var dto = new TraqUserDto() { };

        return await _client.PostJsonAsync(dto);
    }

    public async Task<TraqUserDto> Update(CreateUserViewModel model)
    {
        var dto = new TraqUserDto() { };

        return await _client.PatchJsonSync(dto);
    }
}
