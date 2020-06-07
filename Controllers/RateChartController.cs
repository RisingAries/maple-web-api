using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateChartController : ControllerBase
    {
        private readonly RateChartContext _context;

        public RateChartController(RateChartContext context)
        {
            _context = context;
        }

        // GET: api/RateChart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RateChartItem>>> GetRateChartItem()
        {
            return await _context.RateChartItem.ToListAsync();
        }

        // GET: api/RateChart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RateChartItem>> GetRateChartItem(long id)
        {
            var rateChartItem = await _context.RateChartItem.FindAsync(id);

            if (rateChartItem == null)
            {
                return NotFound();
            }

            return rateChartItem;
        }

        // PUT: api/RateChart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRateChartItem(long id, RateChartItem rateChartItem)
        {
            if (id != rateChartItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(rateChartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateChartItemExists(id))
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

        // POST: api/RateChart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RateChartItem>> PostRateChartItem(RateChartItem rateChartItem)
        {
            _context.RateChartItem.Add(rateChartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRateChartItem", new { id = rateChartItem.Id }, rateChartItem);
        }

        // DELETE: api/RateChart/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RateChartItem>> DeleteRateChartItem(long id)
        {
            var rateChartItem = await _context.RateChartItem.FindAsync(id);
            if (rateChartItem == null)
            {
                return NotFound();
            }

            _context.RateChartItem.Remove(rateChartItem);
            await _context.SaveChangesAsync();

            return rateChartItem;
        }

        private bool RateChartItemExists(long id)
        {
            return _context.RateChartItem.Any(e => e.Id == id);
        }
    }
}
