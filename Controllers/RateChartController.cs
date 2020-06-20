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
    public class RateChartController : ControllerBase
    {
        private readonly IInsuranceInfoRepository _repository;

        public RateChartController(IInsuranceInfoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/RateChart
        [HttpGet]
        public IActionResult GetRateChartItem()
        {
            return Ok(_repository.GetRates());
        }

        // GET: api/RateChart/5
        [HttpGet("{id}")]
        public IActionResult GetRateChartItem(int id)
        {
            var rateChartItem = _repository.GetRate(id);

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
            try
            {
                _repository.EditRate(rateChartItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.RateChartItemExists(id))
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
            _repository.SaveRate(rateChartItem);


            return CreatedAtAction("GetRateChartItem", new { id = rateChartItem.RateId }, rateChartItem);
        }

        // DELETE: api/RateChart/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRateChartItem(int id)
        {
            var rateChartItem = _repository.GetRate(id);
            if (rateChartItem == null)
            {
                return NotFound();
            }
            _repository.DeleteRate(rateChartItem);
            return NoContent();
        }


    }
}
