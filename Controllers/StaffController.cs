using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrAppApi.Data;
using HrAppApi.Models;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StaffController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff
                .Include(s => s.Department)
                .ToListAsync();
        }

        // GET: api/staff/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staff
                    .Include(s => s.Department)
                    .FirstOrDefaultAsync(s => s.Id == id);

            if (staff == null)
                return NotFound();

            return staff;
        }

        // POST: api/staff
        [HttpPost]
        public async Task<ActionResult<Staff>> CreateStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStaff), new { id = staff.Id }, staff);
        }

        // PUT: api/staff/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, Staff updatedStaff)
        {
            if (id != updatedStaff.Id)
                return BadRequest();

            _context.Entry(updatedStaff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/staff/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
                return NotFound();

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
