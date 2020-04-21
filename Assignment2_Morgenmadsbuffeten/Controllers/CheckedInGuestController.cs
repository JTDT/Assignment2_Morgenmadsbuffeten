using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2_Morgenmadsbuffeten.Data;
using Assignment2_Morgenmadsbuffeten.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2_Morgenmadsbuffeten.Controllers
{
    [Authorize("IsWaiter")]
    public class CheckedInGuestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckedInGuestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckedInGuest
        [AllowAnonymous]
        public async Task<IActionResult> Index(DateTime date)
        {
           
            if (date.Year == 1)
            {
                date = DateTime.Today;
            }
           

            var checkedIn = (await _context.CheckedInGuests.ToListAsync()).Where(x => x.Date.Day == date.Day);
           

            return View(checkedIn);

            
        }

        // GET: CheckedInGuest/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests
                .FirstOrDefaultAsync(m => m.CheckedInGuestId == id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }

            return View(checkedInGuest);
        }

        // GET: CheckedInGuest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckedInGuest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckedInGuestId,Date,RoomNumber,Adults,Children")] CheckedInGuest checkedInGuest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkedInGuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkedInGuest);
        }

        // GET: CheckedInGuest/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests.FindAsync(id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }
            return View(checkedInGuest);
        }

        // POST: CheckedInGuest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CheckedInGuestId,Date,RoomNumber,Adults,Children")] CheckedInGuest checkedInGuest)
        {
            if (id != checkedInGuest.CheckedInGuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkedInGuest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckedInGuestExists(checkedInGuest.CheckedInGuestId))
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
            return View(checkedInGuest);
        }

        // GET: CheckedInGuest/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInGuest = await _context.CheckedInGuests
                .FirstOrDefaultAsync(m => m.CheckedInGuestId == id);
            if (checkedInGuest == null)
            {
                return NotFound();
            }

            return View(checkedInGuest);
        }

        // POST: CheckedInGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var checkedInGuest = await _context.CheckedInGuests.FindAsync(id);
            _context.CheckedInGuests.Remove(checkedInGuest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckedInGuestExists(long id)
        {
            return _context.CheckedInGuests.Any(e => e.CheckedInGuestId == id);
        }
    }
}
