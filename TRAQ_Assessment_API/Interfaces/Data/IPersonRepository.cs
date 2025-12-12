using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Interfaces.Data;

public interface IPersonRepository : IRepositoryBase<Person>
{
    public Task<List<Person>> Search(string query);
}
