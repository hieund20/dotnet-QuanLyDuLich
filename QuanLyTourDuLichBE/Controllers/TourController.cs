using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyTourDuLichBE.Models;

namespace QuanLyTourDuLichBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly QLTourDuLichContext _context;
        public TourController(QLTourDuLichContext context)
        {
            _context = context;
        }

        // GET: api/Tour
        [HttpGet]
        public async Task<ActionResult<List<Tour>>> GetTours()
        {
            return await _context.Tour.Select(x => x).ToListAsync();
        }

        // GET: api/Tour/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int id)
        {
            var tour = await _context.Tour.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // POST: api/Tour/Create
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
            _context.Tour.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTour), 
                new { id = tour.Id },
                tour
            );
        }

        // PUT: api/Tour/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, Tour tour)
        {
            if (id != tour.Id)
            {
                return BadRequest();
            }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // DELETE: api/Tour/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            var tour = await _context.Tour.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tour.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(int id)
        {
            return _context.Tour.Any(e => e.Id == id);
        }
    }
}
