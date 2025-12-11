using TRAQ_Assessment_MVC.Models;

namespace TRAQ_Assessment_MVC.Interfaces
{
    public interface IBaseInterface<T, in TCommand>
    where TCommand : BaseCommand
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetList();
        public Task<List<T>> GetList(int id);
        public Task<T> Post(TCommand model);
        public Task<T> Update(TCommand model);
    }
}
