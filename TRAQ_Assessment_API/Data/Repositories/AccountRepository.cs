using Microsoft.EntityFrameworkCore;
using TRAQ_Assessment_API.Data.DBContext;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    public readonly TraqDBContext _db;

    public AccountRepository(TraqDBContext db)
    {
        _db = db;
    }

    public async Task<Account> GetById(int id)
    {
        return await _db.Accounts.FirstAsync(m => m.Code == id);
    }

    public async Task<List<Account>> GetList()
    {
        return await _db.Accounts.ToListAsync();
    }

    public async Task<Account> Post(Account model)
    {
        await _db.Accounts.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Account> Update(Account model)
    {
        var person = await _db.Accounts.FindAsync(model.Code);

        if (person == null)
            return null;

        await _db.SaveChangesAsync();

        return person;
    }
}
