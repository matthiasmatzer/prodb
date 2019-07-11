using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProDB.Models;

namespace ProDB.Controllers
{
    public class ProtagonistController : Controller
    {
        private readonly ProtagonistContext _context;

        public ProtagonistController(ProtagonistContext context)
        {
            _context = context;
        }

        // GET: Protagonist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Protagonists.ToListAsync());
        }

        // GET: Protagonist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protagonist = await _context.Protagonists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (protagonist == null)
            {
                return NotFound();
            }

            return View(protagonist);
        }

        // GET: Protagonist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Protagonist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,firstName,lastName,lastBooking")] Protagonist protagonist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protagonist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protagonist);
        }

        // GET: Protagonist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protagonist = await _context.Protagonists.FindAsync(id);
            if (protagonist == null)
            {
                return NotFound();
            }
            return View(protagonist);
        }

        // POST: Protagonist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,firstName,lastName,lastBooking")] Protagonist protagonist)
        {
            if (id != protagonist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protagonist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtagonistExists(protagonist.ID))
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
            return View(protagonist);
        }

        // GET: Protagonist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protagonist = await _context.Protagonists
                .FirstOrDefaultAsync(m => m.ID == id);
            if (protagonist == null)
            {
                return NotFound();
            }

            return View(protagonist);
        }

        // POST: Protagonist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protagonist = await _context.Protagonists.FindAsync(id);
            _context.Protagonists.Remove(protagonist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtagonistExists(int id)
        {
            return _context.Protagonists.Any(e => e.ID == id);
        }
    }
}
