using AutoMapper;
using TRAQ_Assessment_DLL.Constants;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Transaction;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service;

public class TransactionService : ITransactionService
{
    private readonly BaseClient<TransactionDto> _client;
    private readonly IMapper _mapper;

    public TransactionService(IMapper mapper)
    {
        this._client = new BaseClient<TransactionDto>(UrlConstants.Transaction);
        this._mapper = mapper;
    }

    public async Task<List<TransactionDto>> GetList()
    {
        return await _client.GetList();
    }

    public async Task<TransactionDto> GetById(int id)
    {
        return await _client.GetById(id);
    }

    public async Task<TransactionDto> Post(CreateTransactionViewModel model)
    {

        return await _client.PostJsonAsync(_mapper.Map<TransactionDto>(model));
    }

    public async Task<TransactionDto> Update(CreateTransactionViewModel model)
    {

        return await _client.PatchJsonSync(_mapper.Map<TransactionDto>(model));
    }

    public async Task<List<ViewTransactionViewModel>> GetViewModelList(int id, int holderCode)
    {
        var data = await GetList(id);

        var viewModel = _mapper.Map<List<ViewTransactionViewModel>>(data);

        foreach (var item in viewModel)
        {
            item.HolderCode = holderCode;
        }

        return viewModel;
    }

    public async Task<ViewTransactionViewModel> GetViewModel(int id)
    {
        var data = await GetById(id);

        return _mapper.Map<ViewTransactionViewModel>(data);
    }

    public async Task<List<TransactionDto>> GetList(int id)
    {
        return await _client.GetList(id);
    }
}
