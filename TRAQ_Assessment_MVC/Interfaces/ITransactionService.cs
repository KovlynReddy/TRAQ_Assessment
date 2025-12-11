using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.Account;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.Transaction;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface ITransactionService : IBaseInterface<TransactionDto, CreateUserViewModel>
    {
        public Task<List<ViewTransactionViewModel>> GetViewModelList(int id, int holderCode);
        public Task<ViewTransactionViewModel> GetViewModel(int id);
    }
}
