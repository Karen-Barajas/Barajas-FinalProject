using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheMaxieInn.Data;
using TheMaxieInn.Models;

namespace TheMaxieInn.Controllers
{
    public class DogReservationsController : Controller
    {
        private readonly TheMaxieInnContext _context;

        public DogReservationsController(TheMaxieInnContext context)
        {
            _context = context;
        }

        // GET: DogReservations
        public async Task<IActionResult> Index()
        {
            return View(await _context.DogReservation.ToListAsync());
        }

        // GET: DogReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogReservation = await _context.DogReservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogReservation == null)
            {
                return NotFound();
            }

            return View(dogReservation);
        }

        // GET: DogReservations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DogReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckInDate,CheckOutDate,OwnerName,Address,City,State,ZipCode,Email,PhoneNumber,DogName,DateOfBirth,Breed,Sex,SpayedOrNeutered,Vaccinated,SpecialAccommodation,AccommodationDetails")] DogReservation dogReservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogReservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dogReservation);
        }

        // GET: DogReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogReservation = await _context.DogReservation.FindAsync(id);
            if (dogReservation == null)
            {
                return NotFound();
            }
            return View(dogReservation);
        }

        // POST: DogReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckInDate,CheckOutDate,OwnerName,Address,City,State,ZipCode,Email,PhoneNumber,DogName,DateOfBirth,Breed,Sex,SpayedOrNeutered,Vaccinated,SpecialAccommodation,AccommodationDetails")] DogReservation dogReservation)
        {
            if (id != dogReservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogReservationExists(dogReservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dogReservation);
        }

        // GET: DogReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogReservation = await _context.DogReservation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dogReservation == null)
            {
                return NotFound();
            }

            return View(dogReservation);
        }

        // POST: DogReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogReservation = await _context.DogReservation.FindAsync(id);
            if (dogReservation != null)
            {
                _context.DogReservation.Remove(dogReservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogReservationExists(int id)
        {
            return _context.DogReservation.Any(e => e.Id == id);
        }
    }
}