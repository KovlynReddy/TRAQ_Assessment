using Microsoft.EntityFrameworkCore;
using TRAQ_Assessment_API.Data.DBContext;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    public readonly TraqDBContext _db;

    public PersonRepository(TraqDBContext db)
    {
        _db = db;
    }

    public async Task<Person> Delete(int id)
    {
        var model = await _db.Persons.FirstAsync(m => m.Code == id);
        if (await ValidateDelete(model))
        {
            return null;
        }

        _db.Persons.Remove(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Person> GetById(int id)
    {
        return await _db.Persons.FirstAsync(m => m.Code == id);
    }

    public async Task<List<Person>> GetList()
    {
        return await _db.Persons.ToListAsync();
    }

    public async Task<List<Person>> GetList(int id)
    {
        return await _db.Persons.ToListAsync();
    }

    public async Task<Person> Post(Person model)
    {
        // Person Validation 
        if (await Validate(model))
        {
            return null;
        }

        await _db.Persons.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<List<Person>> Search(string query)
    {
        var accounts = (await _db.Accounts.Where(m => m.Account_Number.ToLower().Contains(query.ToLower())).ToListAsync()).Select(k => k.Person_Code);

        return await _db.Persons.Where(m => m.Surname.ToLower().Contains(query.ToLower()) || m.ID_Number.ToLower().Contains(query.ToLower()) || accounts.Contains(m.Code)).ToListAsync();
    }

    public async Task<Person> Update(Person model)
    {
        var person = await _db.Persons.FindAsync(model.Code);

        if (person == null || await Validate(person))
            return null;

        person.Name = model.Name;
        person.Surname = model.Surname;
        person.ID_Number = model.ID_Number;

        await _db.SaveChangesAsync();

        return person;
    }

    private async Task<bool> Validate(Person model)
    { 
        var validate = await _db.Persons.FirstOrDefaultAsync(m => m.ID_Number == model.ID_Number && m.Code != model.Code);

        return validate != null;
    }

    private async Task<bool> ValidateDelete(Person model)
    {
        var buffer = await _db.Accounts.Where(m => m.Person_Code == model.Code).ToListAsync();
        var validateAccounts = (buffer).Count > 0;
        var validate = await _db.Persons.FirstOrDefaultAsync(k => k.ID_Number == model.ID_Number);

        return validate != null || validateAccounts;
    }
}
