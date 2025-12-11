namespace TRAQ_Assessment_API.Interfaces.Data;

public interface IRepositoryBase<T>
{
    public Task<T> GetById(int id);
    public Task<List<T>> GetList();
    public Task<List<T>> GetList(int id);
    public Task<T> Post(T model);
    public Task<T> Update(T model);
}
