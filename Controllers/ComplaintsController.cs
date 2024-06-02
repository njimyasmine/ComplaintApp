using complaintApp.Data;
using complaintApp.Enums;
using complaintApp.Models;
using complaintApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace complaintApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComplaintsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetComplaints()
        {
            return await _context.Complaints.Include(c => c.Customer).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(int id)
        {
            var complaint = await _context.Complaints.Include(c => c.Customer).FirstOrDefaultAsync(c => c.Id == id);
            return complaint == null ? NotFound() : complaint;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint(int id, ComplaintViewModel complaint)
        {
            if (id != complaint.Id)
                return BadRequest();

            var existingComplaint = await _context.Complaints.FirstOrDefaultAsync(c => c.Id == id);
            if (existingComplaint == null)
                return NotFound("Complaint doesn't exist.");

            if (existingComplaint.Status != Status.Open && existingComplaint.Status != Status.InProgress)
                return BadRequest("Complaint cannot be updated.");

            existingComplaint.Description = complaint.Description;
            existingComplaint.Status = complaint.Status;
            existingComplaint.ProductId = complaint.ProductId;
            existingComplaint.Date = complaint.Date;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintExists(id))
                    return NotFound();
                else
                    throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Complaint>> PostComplaint([FromBody] Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComplaint), new { id = complaint.Id }, complaint);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
                return NotFound();

            complaint.Status = Status.Canceled;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetSearchedComplaints")]
        public async Task<ActionResult<IEnumerable<Complaint>>> GetSearchedComplaints(
            [FromQuery] int? productId,
            [FromQuery] string? customerName,
            [FromQuery] Status? status)
        {
            var query = _context.Complaints.AsQueryable();

            if (productId.HasValue)
                query = query.Where(c => c.ProductId == productId.Value);

            if (!string.IsNullOrEmpty(customerName))
                query = query.Where(c => c.Customer.Name.Contains(customerName));

            if (status.HasValue)
                query = query.Where(c => c.Status == status.Value);

            return await query.ToListAsync();
        }

        private bool ComplaintExists(int id) => _context.Complaints.Any(e => e.Id == id);
    }
}
