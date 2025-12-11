using Microsoft.EntityFrameworkCore;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.DBContext;

public class TraqDBContext : DbContext
{
    public TraqDBContext(DbContextOptions<TraqDBContext> options)
        : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}