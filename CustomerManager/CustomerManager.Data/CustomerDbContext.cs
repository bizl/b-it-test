using CustomerManager.Data.Interfaces;
using CustomerManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace CustomerManager.Data
{
    public class CustomerDbContext : DbContext, IRepository<Customer>
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
        {
        }
         
        public DbSet<Customer> Items { get; set; } = null!;

        public List<Customer> Get(Customer t)
        {
            return Items.Where(x => t.Id == x.Id).ToList();
        }

        public int Insert(Customer t, Guid createUser)
        {
            int result = 1;
            try
            {
                Items.Add(t);
            }   
            catch(Exception ex)
            {
                result = 0;
            }
            return result; 
        }
    }
}