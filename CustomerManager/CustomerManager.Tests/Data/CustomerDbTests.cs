using CustomerManager.Data;
using CustomerManager.Data.Interfaces;
using CustomerManager.Domain; 
using NUnit.Framework;

namespace CustomerManager.Tests.Data
{
    [TestFixture]
    public class CustomerDbTests
    {

        private IRepository<Customer> _repo; 

        [SetUp]
        public void SetUp()
        { 
            //var opts = new DbContextOptionsBuilder<CustomerDbContext>()
            //    .UseMemoryCache(_memoryCache);
            _repo = new CustomerDbContext("Server=(localdb)\\mssqllocaldb;Database=aspnet-CustomerManager.Web-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");

            _repo.Insert(new Customer {Id=1, FirstName = "aaa" }, Guid.NewGuid()); 

        }

        [Test]
        public void CanGetCustomerRecord()
        {
            var customers = _repo.Get(new Customer { Id = 1 });
            Assert.AreEqual(1, customers.Count());
            customers = _repo.Get(new Customer { });
            Assert.IsTrue(customers.Count() > 0);
        }

        [Test]
        public void CanInsertCustomerRecord()
        {
            var result = _repo.Insert(new Customer { FirstName = "Tester 1", LastName = "Jan", Age = 30, Telephone = "0849402094", Reference = "4434fsfg" }, Guid.Parse("fefa70e4-4970-4188-9e7d-2ac4a3f8e31b"));
            Assert.AreEqual(1, result);

        }
    }
}