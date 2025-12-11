using TRAQ_Assessment_API.Data.DBContext;
using TRAQ_Assessment_API.Interfaces.Data;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly TraqDBContext _db;

        public UserRepository(TraqDBContext db)
        {
            _db = db;
        }

        public Task<TraqUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TraqUser>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<List<TraqUser>> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TraqUser> Post(TraqUser model)
        {
            throw new NotImplementedException();
        }

        public Task<TraqUser> Update(TraqUser model)
        {
            throw new NotImplementedException();
        }

        //public async Task<TraqUser> GetById(int id)
        //{
        //    return await _db.Transactions.FirstAsync(m => m.Code == id);
        //}

        //public async Task<List<TraqUser>> GetList()
        //{
        //    return await _db.Transactions.ToListAsync();
        //}

        //public async Task<TraqUser> Post(TraqUser model)
        //{
        //    await _db.Transactions.AddAsync(model);
        //    await _db.SaveChangesAsync();

        //    return model;
        //}

        //public async Task<TraqUser> Update(TraqUser model)
        //{
        //    var person = await _db.Users.FindAsync(model.Code);

        //    if (person == null)
        //        return null;

        //    await _db.SaveChangesAsync();

        //    return person;
        //}
    }
}
