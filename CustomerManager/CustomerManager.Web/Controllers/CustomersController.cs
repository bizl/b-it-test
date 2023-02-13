﻿using CustomerManager.Data.Interfaces;
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

        // GET api/<CustomersController>/5
        [HttpGet]
        [Route("{id}")]
        public Customer Get(long id)
        {
            return _customerRepository.Get(new Customer { Id =id }).FirstOrDefault();
        }

        // POST api/<CustomersController>
        [HttpPost]
        [Route("{id}")]
        public ActionResult Post(long id, [FromBody] Customer sent)
        {
            var customer = _customerRepository.Get(new Customer { Id = id }).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest(  "Customer already exists"  );
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid user;
            Guid.TryParse(userId, out user);
            _customerRepository.Insert(customer, user);

            return Ok("Created");
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public  ActionResult Put(long id, [FromBody] Customer sent)
        {

            var customer = _customerRepository.Get(new Customer { Id = sent.Id }).FirstOrDefault();
            if (customer == null)
            {
                return BadRequest( "Customer not found");
            }

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); 
                Guid user;
                Guid.TryParse(userId, out user);
                _customerRepository.Update(sent, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return NotFound ();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete]
        public void Delete(int id)
        {
           throw new NotImplementedException();
        }
    }
}
