using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Interfaces;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Service
{
    public class AccountService : IAccountService
    {
        public Task<AccountDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountDto>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto> Post(CreateUserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto> Update(CreateUserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
