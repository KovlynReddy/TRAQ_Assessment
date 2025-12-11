using Microsoft.EntityFrameworkCore;
using System;
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

    public Task<Transaction> Delete(int id)
    {
        throw new NotImplementedException();
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
        if (await Validate(model))
        {
            return null;
        }

        var account = await _db.Accounts.FirstAsync(m => m.Code == model.Account_Code);

        account.Outstanding_Balance += model.Amount;
        model.Capture_Date = DateTime.Now;

        await _db.Transactions.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Transaction> Update(Transaction model)
    {
        var person = await _db.Transactions.FindAsync(model.Code);
        var difference = person.Amount - model.Amount;

        if (person == null || await Validate(person))
            return null;

        person.Description = model.Description;
        person.Transaction_Date = model.Transaction_Date;
        person.Capture_Date = DateTime.Now;
        person.Amount = model.Amount;

        var account = await _db.Accounts.FirstAsync(m => m.Code == model.Account_Code);

        account.Outstanding_Balance += difference;

        await _db.SaveChangesAsync();

        return person;
    }

    private async Task<bool> Validate(Transaction model)
    {
        var validateDates = model.Transaction_Date.Date > DateTime.Now.Date;

        var validateAccount = model.Account_Code == 0 || ((await _db.Accounts.FirstAsync(m => m.Code == model.Account_Code)) == null);

        var validateAmount = model.Amount == 0;

        return validateDates || validateAccount || validateAmount;
    }
}
