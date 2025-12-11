using AutoMapper;
using TRAQ_Assessment_DLL.Constants;
using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Client;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.Account;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service
{
    public class AccountService : IAccountService
    {
        private readonly BaseClient<AccountDto> _client;
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper)
        {
            this._mapper = mapper;
            this._client = new BaseClient<AccountDto>(UrlConstants.Account);
        }

        public async Task<AccountDto> GetById(int id)
        {
            return await _client.GetById(id);
        }

        public Task<List<AccountDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountDto> Post(CreateAccountViewModel model)
        {
            return await _client.PatchJsonSync(_mapper.Map<AccountDto>(model));
        }

        public async Task<AccountDto> Update(CreateAccountViewModel model)
        {
            return await _client.PatchJsonSync(_mapper.Map<AccountDto>(model));
        }

        public async Task<List<ViewAccountViewModel>> GetViewModelList(int id)
        {
            var data = await GetList(id);

            return _mapper.Map<List<ViewAccountViewModel>>(data);
        }

        public async Task<ViewAccountViewModel> GetViewModel(int id)
        {
            var data = await GetById(id);

            return _mapper.Map<ViewAccountViewModel>(data);
        }

        public async Task<List<AccountDto>> GetList(int id)
        {
            return await _client.GetList(id);
        }
    }
}
