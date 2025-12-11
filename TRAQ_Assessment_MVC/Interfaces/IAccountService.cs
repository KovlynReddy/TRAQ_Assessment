using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface IAccountService : IBaseInterface<AccountDto, CreateUserViewModel>
    {
    }
}
