using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragePlanController : ControllerBase
    {
        private readonly CoveragePlanContext _context;

        public CoveragePlanController(CoveragePlanContext context)
        {
            _context = context;
        }

        // GET: api/CoveragePlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoveragePlanItem>>> GetCoveragePlanItem()
        {
            return await _context.CoveragePlanItem.ToListAsync();
        }

        // GET: api/CoveragePlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoveragePlanItem>> GetCoveragePlanItem(long id)
        {
            var coveragePlanItem = await _context.CoveragePlanItem.FindAsync(id);

            if (coveragePlanItem == null)
            {
                return NotFound();
            }

            return coveragePlanItem;
        }

        // PUT: api/CoveragePlan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoveragePlanItem(long id, CoveragePlanItem coveragePlanItem)
        {
            if (id != coveragePlanItem.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(coveragePlanItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoveragePlanItemExists(id))
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

        // POST: api/CoveragePlan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CoveragePlanItem>> PostCoveragePlanItem(CoveragePlanItem coveragePlanItem)
        {
            _context.CoveragePlanItem.Add(coveragePlanItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoveragePlanItem", new { id = coveragePlanItem.PlanId }, coveragePlanItem);
        }

        // DELETE: api/CoveragePlan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CoveragePlanItem>> DeleteCoveragePlanItem(long id)
        {
            var coveragePlanItem = await _context.CoveragePlanItem.FindAsync(id);
            if (coveragePlanItem == null)
            {
                return NotFound();
            }

            _context.CoveragePlanItem.Remove(coveragePlanItem);
            await _context.SaveChangesAsync();

            return coveragePlanItem;
        }

        private bool CoveragePlanItemExists(long id)
        {
            return _context.CoveragePlanItem.Any(e => e.PlanId == id);
        }
    }
}
