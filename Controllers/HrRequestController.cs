using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrAppApi.Models;
using HrAppApi.Data;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HrRequestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HrRequestController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/hrrequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HrRequest>>> GetRequests([FromQuery] string? type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                return await _context.HrRequests
                    .Where(r => r.Type.ToLower() == type.ToLower())
                    .ToListAsync();
            }

            return await _context.HrRequests.ToListAsync();
        }

        // GET: api/hrrequest/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HrRequest>> GetRequest(int id)
        {
            var request = await _context.HrRequests.FindAsync(id);
            if (request == null) return NotFound();
            return request;
        }

        // POST: api/hrrequest
        [HttpPost]
        public async Task<ActionResult<HrRequest>> CreateRequest(HrRequest request)
        {
            request.Status ??= "Pending"; // default status
            _context.HrRequests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRequest), new { id = request.Id }, request);
        }

        // PUT: api/hrrequest/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, HrRequest updated)
        {
            if (id != updated.Id) return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/hrrequest/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.HrRequests.FindAsync(id);
            if (request == null) return NotFound();

            _context.HrRequests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
