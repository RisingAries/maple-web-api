using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maple_web_api.Models;
using Microsoft.Extensions.Logging;
using maple_web_api.Services;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractItemsController : ControllerBase
    {
        private readonly IInsuranceInfoRepository _repository;
        private readonly ILogger<ContractItemsController> _logger;

        public ContractItemsController(IInsuranceInfoRepository repository, ILogger<ContractItemsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/ContractItems
        [HttpGet]
        public IActionResult GetContractItems()
        {
            return Ok(_repository.GetContracts());
        }

        // GET: api/ContractItems/5
        [HttpGet("{id}", Name = "GetContract")]
        public IActionResult GetContractItem(int id)
        {
            var contractItem = _repository.GetContract(id);

            if (contractItem == null)
            {
                _logger.LogInformation($"Contract with id {id} not found.");
                return NotFound();
            }
            /*    contractItem.Customer = _repository.GetCustomer(contractItem.CustomerId);
               contractItem.CoveragePlan = _repository.GetCoveragePlan(contractItem.ContractId); */
            return Ok(contractItem);
        }

        // PUT: api/ContractItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut()]
        public IActionResult PutContractItem(string customerName, DateTime dob, string gender)
        {
            Customer customer = _repository.GetCustomerByName(customerName);
            if (customer == null)
            {
                _logger.LogInformation($"Customer with name {customerName} not found.");
                ModelState.AddModelError("Customer Name", "No Customer with this name!");
                return BadRequest(ModelState);
            }
            var planType = _repository.GetCoveragePlan(customer.Country, customer.DateOfBirth);
            var age = DateTime.Now.Year - dob.Year;

            if (planType == null)
            {
                _logger.LogInformation($"Suitable Coverage Plan for the provided parameters not found.");
                ModelState.AddModelError("Coverage Plan", "Coverage Plan not found!");
                return BadRequest(ModelState);
            }
            object g = null;
            Gender cgender = (Gender)
            (Enum.TryParse(typeof(Gender), gender, true, out g) ? g : Gender.Other);
            var rate = _repository.GetRate(cgender, age, planType);
            if (rate == null)
            {
                _logger.LogInformation($"Rate not found for the Plan Id {planType.PlanId}.");
                ModelState.AddModelError("Rate", "Rate not found!");
                return BadRequest(ModelState);
            }
            var contractItem = new ContractItem
            {
                CustomerId = customer.CustomerId,
                SaleDate = DateTime.Now.Date,
                CoverageId = planType.PlanId,
                NetPrice = rate.NetPrice
            };

            _repository.EditContract(contractItem);

            return NoContent();
        }

        // POST: api/ContractItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost()]
        public IActionResult PostContractItem([FromBody] ContractDetailsForPostDto contractDetails)
        {
            var customer = _repository.GetCustomerByName(contractDetails.CustomerName);
            if (customer == null)
            {
                _logger.LogInformation($"Customer with name {contractDetails.CustomerName} not found.");
                ModelState.AddModelError("Customer Name", "Customer does not exist!");
                return BadRequest(ModelState);
            }
            var planType = _repository.GetCoveragePlan(contractDetails.CustomerCountry, customer.DateOfBirth);
            var age = DateTime.Now.Year - contractDetails.DOB.Year;
            if (planType == null)
            {
                _logger.LogInformation("Suitable Coverage Plan not found for provided paramters.");
                ModelState.AddModelError("Coverage Plan", "Coverage Plan not found!");
                return BadRequest(ModelState);
            }
            object g = null;
            Gender gender = (Gender)
            (Enum.TryParse(typeof(Gender), contractDetails.CustomerGender, true, out g) ? g : Gender.Other);
            var rate = _repository.GetRate(gender, age, planType);
            if (rate == null)
            {
                _logger.LogInformation($"Rate not found for Plan Id {planType.PlanId}.");
                ModelState.AddModelError("Rate", "Rate not found!");
                return BadRequest(ModelState);
            }
            var contractItem = new ContractItem
            {
                CustomerId = customer.CustomerId,
                SaleDate = contractDetails.SaleDate,
                CoverageId = planType.PlanId,
                NetPrice = rate.NetPrice
            };
            try
            {
                _repository.SaveContract(contractItem);

            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogCritical("Database update concurrency exception thrown", ex);
                return StatusCode(500, "Internal Server Error has occurred.");
            }


            return CreatedAtAction("GetContract", new { id = contractItem.ContractId }, contractItem);
        }

        // DELETE: api/ContractItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContractItem(int id)
        {
            var contractItem = _repository.GetContract(id);
            if (contractItem == null)
            {
                _logger.LogInformation($"No contract found with id {id}.");
                ModelState.AddModelError("Id", "No Contract Found!");
                return BadRequest(ModelState);
            }
            _repository.DeleteContract(contractItem);

            return NoContent();
        }

        private bool ContractItemExists(int id)
        {
            return _repository.GetContract(id) != null ? true : false;
        }
    }
}
