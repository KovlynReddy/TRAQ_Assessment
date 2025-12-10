using TRAQ_Assessment_DLL.Constants;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service;

public class TransactionService : ITransactionService
{
    private readonly BaseClient<TransactionDto> _client;

    public TransactionService()
    {
        this._client = new BaseClient<TransactionDto>(UrlConstants.User);
    }

    public async Task<List<TransactionDto>> GetList()
    {
        return await _client.GetList();
    }

    public async Task<TransactionDto> GetById(string id)
    {
        return await _client.GetById(id);
    }

    public async Task<TransactionDto> Post(CreateUserViewModel model)
    {
        var dto = new TransactionDto() { };

        return await _client.PostJsonAsync(dto);
    }

    public async Task<TransactionDto> Update(CreateUserViewModel model)
    {
        var dto = new TransactionDto() { };

        return await _client.PatchJsonSync(dto);
    }
}
