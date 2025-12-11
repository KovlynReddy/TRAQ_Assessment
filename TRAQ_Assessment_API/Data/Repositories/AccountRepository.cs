using Microsoft.EntityFrameworkCore;
using System;
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

    public async Task<Account> Delete(int id)
    {
        var model = await _db.Accounts.FirstAsync(m => m.Code == id);
        if (await ValidateDelete(model))
        {
            return null;
        }

        _db.Accounts.Remove(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Account> GetById(int id)
    {
        return await _db.Accounts.FirstAsync(m => m.Code == id);
    }

    public async Task<List<Account>> GetList()
    {
        return await _db.Accounts.ToListAsync();
    }

    public async Task<List<Account>> GetList(int id)
    {
        return await _db.Accounts.Where(m => m.Person_Code == id).ToListAsync();
    }

    public async Task<Account> Post(Account model)
    {
        // account Validation 
        if (await Validate(model))
        {
            return null;
        }

        await _db.Accounts.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Account> Update(Account model)
    {
        var person = await _db.Accounts.FindAsync(model.Code);

        if (person == null || await Validate(person))
            return null;

        person.Account_Number = model.Account_Number;

        await _db.SaveChangesAsync();

        return person;
    }

    private async Task<bool> Validate(Account model)
    {
        var buffer = await _db.Accounts.FirstOrDefaultAsync(m => m.Account_Number == model.Account_Number && m.Code != model.Code);
        var validateAccountNumber = (buffer) != null;
        var buffer2 = await _db.Persons.FirstOrDefaultAsync(m => m.Code == model.Person_Code);
        var validatePerson = model.Person_Code == 0 || (buffer2) == null;

        return validateAccountNumber || validatePerson;
    }
    
    private async Task<bool> ValidateDelete(Account model)
    {
        var validateTransactions = model.Person_Code != 0;

        var buffer = await _db.Accounts.FirstOrDefaultAsync(m => m.Account_Number == model.Account_Number && m.Code != model.Code);
        var validateAccountNumber = (buffer) != null;
        var buffer2 = await _db.Persons.FirstOrDefaultAsync(m => m.Code == model.Person_Code);
        var validatePerson = (buffer2 == null);

        return validateAccountNumber || validatePerson || validateTransactions;
    }
}
