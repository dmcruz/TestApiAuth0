using Microsoft.EntityFrameworkCore;
namespace TestApiAuth0.Data
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
        }

        public DbSet<AccountModel> Accounts { get; set; }
    }
}
