using TRAQ_Assessment_DLL.DTOs;
using TRAQ_Assessment_MVC.Models.Person;
using TRAQ_Assessment_MVC.Models.User;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface IPersonService : IBaseInterface<PersonDto, CreateUserViewModel>
    {
        public Task<List<ViewPersonViewModel>> GetViewModelList();
        public Task<ViewPersonViewModel> GetViewModel(int id);
    }
}
