using Microsoft.EntityFrameworkCore;
using TRAQ_Assessment_DLL.Entities;

namespace TRAQ_Assessment_API.Data.DBContext;

public class TraqDBContext : DbContext
{
    public TraqDBContext(DbContextOptions<TraqDBContext> options)
        : base(options)
    {
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Ignore<Account>();
    //    modelBuilder.Ignore<Person>();
    //    modelBuilder.Ignore<Transaction>();
    //}

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public DbSet<TraqUser> Users { get; set; }
    public DbSet<Status> Status { get; set; }
}