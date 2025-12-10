using TRAQ_Assessment_MVC.Models;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface IBaseInterface<T, in TCommand>
    where TCommand : BaseCommand
    {
        public Task<T> GetById(string id);
        public Task<List<T>> GetList();
        public Task<T> Post(TCommand model);
        public Task<T> Update(TCommand model);
    }
}
