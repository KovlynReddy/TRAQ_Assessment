using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.Account;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface IAccountService : IBaseInterface<AccountDto, CreateAccountViewModel>
    {
        public Task<List<ViewAccountViewModel>> GetViewModelList(int id);
        public Task<ViewAccountViewModel> GetViewModel(int id);
    }
}
