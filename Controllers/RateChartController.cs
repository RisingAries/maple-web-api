using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maple_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateChartController : ControllerBase
    {
        private readonly InsuranceInfoContext _context;

        public RateChartController(InsuranceInfoContext context)
        {
            _context = context;
        }

        // GET: api/RateChart
        [HttpGet]
        public IActionResult GetRateChartItem()
        {
            return Ok(_context.RateCharts.ToList());
        }

        // GET: api/RateChart/5
        [HttpGet("{id}")]
        public IActionResult GetRateChartItem(int id)
        {
            var rateChartItem = _context.RateCharts.Find(id);

            if (rateChartItem == null)
            {
                return NotFound();
            }

            return Ok(rateChartItem);
        }

        // PUT: api/RateChart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRateChartItem(int id, RateChartItem rateChartItem)
        {
            if (id != rateChartItem.RateId)
            {
                return BadRequest();
            }

            _context.Entry(rateChartItem).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateChartItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, "Internal Server error has occurred!");
                }
            }

            return NoContent();
        }

        // POST: api/RateChart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostRateChartItem(RateChartItem rateChartItem)
        {
            _context.RateCharts.Add(rateChartItem);
            _context.SaveChanges();

            return CreatedAtAction("GetRateChartItem", new { id = rateChartItem.RateId }, rateChartItem);
        }

        // DELETE: api/RateChart/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRateChartItem(int id)
        {
            var rateChartItem = _context.RateCharts.Find(id);
            if (rateChartItem == null)
            {
                return NotFound();
            }

            _context.RateCharts.Remove(rateChartItem);
            _context.SaveChanges();

            return NoContent();
        }

        private bool RateChartItemExists(int id)
        {
            return _context.RateCharts.Any(e => e.RateId == id);
        }
    }
}
