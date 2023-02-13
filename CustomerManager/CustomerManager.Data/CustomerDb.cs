using CustomerManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Data
{
    public class CustomerDb : DbContext
    {
        public CustomerDb(DbContextOptions<CustomerDb> options)
        : base(options)
        {
        }
        public DbSet<Customer> Items { get; set; } = null!;
    }
}