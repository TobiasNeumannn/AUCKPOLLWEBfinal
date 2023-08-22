using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUCKPOLLWEB.Areas.Identity.Data;
using AUCKPOLLWEB.Models;

namespace AUCKPOLLWEB.Controllers
{
    public class airQualitiesController : Controller
    {
        private readonly AUCKPOLLWEBContextDb _context;

        public airQualitiesController(AUCKPOLLWEBContextDb context)
        {
            _context = context;
        }

        // GET: airQualities
        public async Task<IActionResult> Index()
        {
            var aUCKPOLLWEBContextDb = _context.airQuality.Include(a => a.Region);
            return View(await aUCKPOLLWEBContextDb.ToListAsync());
        }

        // GET: airQualities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.airQuality == null)
            {
                return NotFound();
            }

            var airQuality = await _context.airQuality
                .Include(a => a.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (airQuality == null)
            {
                return NotFound();
            }

            return View(airQuality);
        }

        // GET: airQualities/Create
        public IActionResult Create()
        {
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID");
            return View();
        }

        // POST: airQualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,regionID,collection_date,value,unit")] airQuality airQuality)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(airQuality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", airQuality.regionID);
            return View(airQuality);
        }

        // GET: airQualities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.airQuality == null)
            {
                return NotFound();
            }

            var airQuality = await _context.airQuality.FindAsync(id);
            if (airQuality == null)
            {
                return NotFound();
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", airQuality.regionID);
            return View(airQuality);
        }

        // POST: airQualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,regionID,collection_date,value,unit")] airQuality airQuality)
        {
            if (id != airQuality.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(airQuality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!airQualityExists(airQuality.ID))
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
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", airQuality.regionID);
            return View(airQuality);
        }

        // GET: airQualities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.airQuality == null)
            {
                return NotFound();
            }

            var airQuality = await _context.airQuality
                .Include(a => a.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (airQuality == null)
            {
                return NotFound();
            }

            return View(airQuality);
        }

        // POST: airQualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.airQuality == null)
            {
                return Problem("Entity set 'AUCKPOLLWEBContextDb.airQuality'  is null.");
            }
            var airQuality = await _context.airQuality.FindAsync(id);
            if (airQuality != null)
            {
                _context.airQuality.Remove(airQuality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool airQualityExists(int id)
        {
          return (_context.airQuality?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
