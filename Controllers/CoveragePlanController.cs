using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maple_web_api.Models;
using maple_web_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoveragePlanController : ControllerBase
    {
        private readonly IInsuranceInfoRepository _respository;

        public CoveragePlanController(IInsuranceInfoRepository context)
        {
            _respository = context;
        }

        // GET: api/CoveragePlan
        [HttpGet]
        public IActionResult GetCoveragePlanItem()
        {
            return Ok(_respository.GetCoveragePlans());
        }

        // GET: api/CoveragePlan/5
        [HttpGet("{id}")]
        public IActionResult GetCoveragePlanItem(int id)
        {
            var coveragePlanItem = _respository.GetCoveragePlan(id);

            if (coveragePlanItem == null)
            {
                return NotFound();
            }

            return Ok(coveragePlanItem);
        }

        // PUT: api/CoveragePlan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCoveragePlanItem(int id, [FromBody] CoveragePlanItem coveragePlanItem)
        {
            if (id != coveragePlanItem.PlanId)
            {
                return BadRequest();
            }
            try
            {
                _respository.EditCoveragePlan(id, coveragePlanItem);
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
        public IActionResult PostCoveragePlanItem(CoveragePlanItem coveragePlanItem)
        {
            _respository.SaveCoveragePlan(coveragePlanItem);


            return CreatedAtAction("GetCoveragePlanItem", new { id = coveragePlanItem.PlanId }, coveragePlanItem);
        }

        // DELETE: api/CoveragePlan/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCoveragePlanItem(int id)
        {
            var coveragePlanItem = _respository.GetCoveragePlan(id);
            if (coveragePlanItem == null)
            {
                return NotFound();
            }

            _respository.DeleteCoveragePlan(coveragePlanItem);

            return NoContent();
        }

        private bool CoveragePlanItemExists(int id)
        {
            return _respository.GetCoveragePlan(id) != null ? true : false;
        }
    }
}
