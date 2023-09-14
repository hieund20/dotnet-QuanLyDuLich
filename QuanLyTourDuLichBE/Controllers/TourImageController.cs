using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyTourDuLichBE.Models;

namespace QuanLyTourDuLichBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourImageController : ControllerBase
    {
        private readonly QLTourDuLichContext _context;
        public TourImageController(QLTourDuLichContext context)
        {
            _context = context;
        }

        // GET: api/TourImage
        [HttpGet]
        public async Task<ActionResult<List<TourImage>>> GetTourImages()
        {
            return await _context.TourImage.Select(x => x).ToListAsync();
        }

        // GET: api/TourImage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourImage>> GetTourImage(int id)
        {
            var tourImage = await _context.TourImage.FindAsync(id);

            if (tourImage == null)
            {
                return NotFound();
            }

            return tourImage;
        }

        // POST: api/TourImage/Create
        [HttpPost]
        public async Task<ActionResult<TourImage>> PostTourImage(TourImage tourImage)
        {
            _context.TourImage.Add(tourImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTourImage), 
                new { id = tourImage.Id },
                tourImage
            );
        }

        // PUT: api/TourImage/Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourImage(int id, TourImage tourImage)
        {
            if (id != tourImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(tourImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourImageExists(id))
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

        // DELETE: api/TourImage/Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourImage(int id)
        {
            var tourImage = await _context.TourImage.FindAsync(id);
            if (tourImage == null)
            {
                return NotFound();
            }

            _context.TourImage.Remove(tourImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourImageExists(int id)
        {
            return _context.TourImage.Any(e => e.Id == id);
        }
    }
}
