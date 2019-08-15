using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BO;
using DAL;

namespace SampleWebAPI.Controllers
{
    //docs.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-2.1
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomer _customer;
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customer.GetAll();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                return Ok(_customer.GetById(id));
            }
            catch(Exception ex)
            {
                return BadRequest($"Kesalahan: {ex.Message}");
            }
        }

        // POST: api/Customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _customer.Insert(customer);
            return Ok("Data Customer berhasil ditambah !");
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
