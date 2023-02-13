using CustomerManager.Data.Interfaces;
using CustomerManager.Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace CustomerManager.Data
{
    public class CustomerDbContext : DbContext, IRepository<Customer>
    {
        string _connectionString;

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
: base(options)
        {

        }

        public CustomerDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Customer> Items { get; set; } = null!;

        public List<Customer> Get(Customer customer)
        {
            IEnumerable<Customer> data;
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                data = conn.Query<Customer>(
                           "select * from dbo.Customers WHERE (Id= @Id or @Id=0)",
                           customer
                          );
            }
            return data.ToList();
        }

        public int Insert(Customer customer, Guid createUser)
        {

            int affectedRows = 0;
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                affectedRows = conn.Execute(
                       "insert into Customers (Text, CreateUser) VALUES (@Text, @CreateUser)",
                      new { Text = JsonConvert.SerializeObject(customer), CreateUser = createUser }
                      );
            }
            return affectedRows;
        }
    }
}