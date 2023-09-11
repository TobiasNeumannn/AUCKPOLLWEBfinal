using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AUCKPOLLWEB.Areas.Identity.Data;
using AUCKPOLLWEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace AUCKPOLLWEB.Controllers
{
    [Authorize]
    public class estuaryQualitiesController : Controller
    {
        private readonly AUCKPOLLWEBContextDb _context;

        public estuaryQualitiesController(AUCKPOLLWEBContextDb context)
        {
            _context = context;
        }

        // GET: estuaryQualities
        public async Task<IActionResult> Index()
        {
            var aUCKPOLLWEBContextDb = _context.estuaryQuality.Include(e => e.Region);
            return View(await aUCKPOLLWEBContextDb.ToListAsync());
        }

        // GET: estuaryQualities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estuaryQuality == null)
            {
                return NotFound();
            }

            var estuaryQuality = await _context.estuaryQuality
                .Include(e => e.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estuaryQuality == null)
            {
                return NotFound();
            }

            return View(estuaryQuality);
        }

        // GET: estuaryQualities/Create
        public IActionResult Create()
        {
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID");
            return View();
        }

        // POST: estuaryQualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,regionID,collection_date,indicator,value")] estuaryQuality estuaryQuality)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(estuaryQuality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", estuaryQuality.regionID);
            return View(estuaryQuality);
        }

        // GET: estuaryQualities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estuaryQuality == null)
            {
                return NotFound();
            }

            var estuaryQuality = await _context.estuaryQuality.FindAsync(id);
            if (estuaryQuality == null)
            {
                return NotFound();
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", estuaryQuality.regionID);
            return View(estuaryQuality);
        }

        // POST: estuaryQualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,regionID,collection_date,indicator,value")] estuaryQuality estuaryQuality)
        {
            if (id != estuaryQuality.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(estuaryQuality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estuaryQualityExists(estuaryQuality.ID))
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
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", estuaryQuality.regionID);
            return View(estuaryQuality);
        }

        // GET: estuaryQualities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estuaryQuality == null)
            {
                return NotFound();
            }

            var estuaryQuality = await _context.estuaryQuality
                .Include(e => e.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estuaryQuality == null)
            {
                return NotFound();
            }

            return View(estuaryQuality);
        }

        // POST: estuaryQualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estuaryQuality == null)
            {
                return Problem("Entity set 'AUCKPOLLWEBContextDb.estuaryQuality'  is null.");
            }
            var estuaryQuality = await _context.estuaryQuality.FindAsync(id);
            if (estuaryQuality != null)
            {
                _context.estuaryQuality.Remove(estuaryQuality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estuaryQualityExists(int id)
        {
          return (_context.estuaryQuality?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
