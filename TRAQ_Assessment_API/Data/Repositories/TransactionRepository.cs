using Microsoft.EntityFrameworkCore;
using TRAQ_Assessment_API.Data.DBContext;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public readonly TraqDBContext _db;

    public TransactionRepository(TraqDBContext db)
    {
        _db = db;
    }

    public async Task<Transaction> GetById(int id)
    {
        return await _db.Transactions.FirstAsync(m => m.Code == id);
    }

    public async Task<List<Transaction>> GetList()
    {
        return await _db.Transactions.ToListAsync();
    }

    public async Task<List<Transaction>> GetList(int id)
    {
        return await _db.Transactions.Where(m => m.Account_Code == id).ToListAsync();
    }

    public async Task<Transaction> Post(Transaction model)
    {
        // Transaction Validation 


        await _db.Transactions.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Transaction> Update(Transaction model)
    {
        var person = await _db.Transactions.FindAsync(model.Code);

        if (person == null)
            return null;

        person.Description = model.Description;
        person.Capture_Date = model.Capture_Date;
        person.Transaction_Date = model.Transaction_Date;
        person.Amount = model.Amount;

        await _db.SaveChangesAsync();

        return person;
    }
}
