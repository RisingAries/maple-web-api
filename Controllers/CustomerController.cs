using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maple_web_api.Models;
using maple_web_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IInsuranceInfoRepository _repository;

        public CustomerController(IInsuranceInfoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Customer
        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok(_repository.GetCustomers());
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _repository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            try
            {

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Internal Server error has occurred!");
                }
            }
            _repository.EditCustomer(customer);


            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            _repository.SaveCustomer(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _repository.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            _repository.DeleteCustomer(customer);

            return NoContent();
        }


    }
}
