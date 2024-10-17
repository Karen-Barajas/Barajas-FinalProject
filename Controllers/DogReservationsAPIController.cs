using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheMaxieInn.Data;
using TheMaxieInn.Models;

namespace TheMaxieInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogReservationsAPIController : ControllerBase
    {
        private readonly TheMaxieInnContext _context;

        public DogReservationsAPIController(TheMaxieInnContext context)
        {
            _context = context;
        }

        // GET: api/DogReservationsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogReservation>>> GetDogReservation()
        {
            return await _context.DogReservation.ToListAsync();
        }

        // GET: api/DogReservationsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogReservation>> GetDogReservation(int id)
        {
            var dogReservation = await _context.DogReservation.FindAsync(id);

            if (dogReservation == null)
            {
                return NotFound();
            }

            return dogReservation;
        }

        // PUT: api/DogReservationsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogReservation(int id, DogReservation dogReservation)
        {
            if (id != dogReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogReservationExists(id))
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

        // POST: api/DogReservationsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogReservation>> PostDogReservation(DogReservation dogReservation)
        {
            _context.DogReservation.Add(dogReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogReservation", new { id = dogReservation.Id }, dogReservation);
        }

        // DELETE: api/DogReservationsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogReservation(int id)
        {
            var dogReservation = await _context.DogReservation.FindAsync(id);
            if (dogReservation == null)
            {
                return NotFound();
            }

            _context.DogReservation.Remove(dogReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogReservationExists(int id)
        {
            return _context.DogReservation.Any(e => e.Id == id);
        }
    }
}
