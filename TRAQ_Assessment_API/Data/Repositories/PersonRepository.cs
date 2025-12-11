using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.Entities;
using TRAQ_Assessment_API.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TRAQ_Assessment_API.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    public readonly TraqDBContext _db;

    public PersonRepository(TraqDBContext db)
    {
        _db = db;
    }

    public async Task<Person> GetById(int id)
    {
        return await _db.Persons.FirstAsync(m => m.Code == id);
    }

    public async Task<List<Person>> GetList()
    {
        return await _db.Persons.ToListAsync();
    }

    public async Task<Person> Post(Person model)
    {
        await _db.Persons.AddAsync(model);
        await _db.SaveChangesAsync();

        return model;
    }

    public async Task<Person> Search(int id, string query)
    {
        return await _db.Persons.FirstAsync(m => m.Code == id || m.Surname.ToLower().Contains(query.ToLower()));
    }

    public async Task<Person> Update(Person model)
    {
        var person = await _db.Persons.FindAsync(model.Code);

        if (person == null)
            return null;

        person.Name = model.Name;
        person.Surname = model.Surname;

        await _db.SaveChangesAsync();

        return person;
    }
}
