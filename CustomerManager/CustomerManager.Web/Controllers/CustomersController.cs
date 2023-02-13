using CustomerManager.Data.Interfaces;
using CustomerManager.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CustomerManager.Web.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IRepository<Customer> _customerRepository; 
        public CustomersController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepository.Get(new Customer { });
        }

        // GET api/<CustomersController>/{id}
        [HttpGet]
        [Route("{id}")]
        public Customer Get(long id)
        {
            return _customerRepository.Get(new Customer { Id =id }).FirstOrDefault();
        }

        // POST api/<CustomersController>
        [HttpPost] 
        public ActionResult Post( [FromBody] Customer customerJson)
        {
            var customer = _customerRepository.Get(new Customer { Id = customerJson.Id }).FirstOrDefault();
            if (customer != null)
            {
                return BadRequest("Customer {customerJson.FirstName} {customerJson.LastName} already exists");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid user;
            Guid.TryParse(userId, out user);
            _customerRepository.Insert(customerJson, user);

            return Ok("Created");
        }

        // PUT api/<CustomersController>
        [HttpPut]
        public  ActionResult Put([FromBody] Customer customerJson)
        {

            var customer = _customerRepository.Get(new Customer { Id = customerJson.Id }).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest( "Customer not found");
            }

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); 
                Guid user;
                Guid.TryParse(userId, out user);
                _customerRepository.Update(customerJson, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok ("Customer updated");
        }

        // DELETE api/<CustomersController>/{id}
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.Get(new Customer { Id = id }).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest("Customer record to delete does not exist");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid user;
            Guid.TryParse(userId, out user);
            _customerRepository.Update(customer, user);

            return Ok("Customer record deleted");
        }
    }
}
