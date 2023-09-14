using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyTourDuLichBE.Models;

namespace QuanLyTourDuLichBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Secure Swagger UI with authentication
    public class NewController : ControllerBase
    {
        private readonly QLTourDuLichContext _context;
        public NewController(QLTourDuLichContext context)
        {
            _context = context;
        }

        // GET: api/New
        [HttpGet]
        public async Task<ActionResult<List<New>>> GetNews()
        {
            return await _context.New.Select(x => x).ToListAsync();
        }

        // GET: api/New/5
        [HttpGet("{id}")]
        public async Task<ActionResult<New>> GetNew(int id)
        {
            var newItem = await _context.New.FindAsync(id);

            if (newItem == null)
            {
                return NotFound();
            }

            return newItem;
        }

        // POST: api/New/Create
        [HttpPost]
        public async Task<ActionResult<New>> PostNew(New newItem)
        {
            _context.New.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetNew), 
                new { id = newItem.Id },
                newItem
            );
        }

        // PUT: api/New/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNew(int id, New newItem)
        {
            if (id != newItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(newItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewExists(id))
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

        // DELETE: api/New/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNew(int id)
        {
            var newDelelte = await _context.New.FindAsync(id);
            if (newDelelte == null)
            {
                return NotFound();
            }

            _context.New.Remove(newDelelte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NewExists(int id)
        {
            return _context.New.Any(e => e.Id == id);
        }
    }
}
