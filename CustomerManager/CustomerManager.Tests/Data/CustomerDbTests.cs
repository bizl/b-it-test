using CustomerManager.Data;
using CustomerManager.Data.Interfaces;
using CustomerManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace CustomerManager.Tests.Data
{
    [TestFixture]
    public class CustomerDbTests
    {

        private IRepository<Customer> _repo;
        private Mock<IMemoryCache> _mockCache;

        [SetUp]
        public void SetUp()
        {

            var opts = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseMemoryCache(_mockCache.Object);
            _repo = new CustomerDbContext(opts.Options);
        }


    }
}