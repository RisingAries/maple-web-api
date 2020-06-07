using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maple_web_api.Models;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractItemsController : ControllerBase
    {
        private readonly InsuranceInfoContext _context;

        public ContractItemsController(InsuranceInfoContext context)
        {
            _context = context;
        }

        // GET: api/ContractItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractItem>>> GetContractItems()
        {
            return await _context.ContractItems.ToListAsync();
        }

        // GET: api/ContractItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractItem>> GetContractItem(int id)
        {
            var contractItem = await _context.ContractItems.FindAsync(id);

            if (contractItem == null)
            {
                return NotFound();
            }
            contractItem.Customer = _context.Customers.Where(c => c.CustomerId == contractItem.CustomerId).First();
            contractItem.CoveragePlan = _context.CoveragePlans.Where(cp => cp.PlanId == contractItem.CoverageId).First();
            return contractItem;
        }

        // PUT: api/ContractItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractItem(int id, ContractItem contractItem)
        {
            if (id != contractItem.ContractId)
            {
                return BadRequest();
            }

            _context.Entry(contractItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContractItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost()]
        public async Task<ActionResult<ContractItem>> PostContractItem([FromForm] string customerName, [FromForm] Country country, [FromForm] DateTime dob, [FromForm] string gender, [FromForm] DateTime saleDate)
        {
            var customer = _context.Customers.Where(c => c.Name == customerName).FirstOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            var planType = _context.CoveragePlans.Where(cp => cp.EligibilityCountry == country && cp.EligibilityDateFrom < customer.DateOfBirth && cp.EligibilityDateTo > customer.DateOfBirth).FirstOrDefault();
            var age = DateTime.Now.Year - dob.Year;
            if (planType == null)
            {
                return NotFound();
            }
            var rate = _context.RateCharts.Where(ch => ch.Gender == gender && ch.CuttoffAge > age && ch.CoveragePlan.PlanId == planType.PlanId).FirstOrDefault();
            if (rate == null)
            {
                return NotFound();
            }
            var contractItem = new ContractItem
            {
                CustomerId = customer.CustomerId,
                SaleDate = saleDate,
                CoverageId = planType.PlanId,
                NetPrice = rate.NetPrice
            };
            _context.ContractItems.Add(contractItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContractItem", new { id = contractItem.ContractId }, contractItem);
        }

        // DELETE: api/ContractItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContractItem>> DeleteContractItem(int id)
        {
            var contractItem = await _context.ContractItems.FindAsync(id);
            if (contractItem == null)
            {
                return NotFound();
            }

            _context.ContractItems.Remove(contractItem);
            await _context.SaveChangesAsync();

            return contractItem;
        }

        private bool ContractItemExists(int id)
        {
            return _context.ContractItems.Any(e => e.ContractId == id);
        }
    }
}
