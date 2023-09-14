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
    public class gWaterQualitiesController : Controller
    {
        private readonly AUCKPOLLWEBContextDb _context;

        public gWaterQualitiesController(AUCKPOLLWEBContextDb context)
        {
            _context = context;
        }

        // GET: gWaterQualities
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.gWaterQuality.Include(g => g.Region) == null)
            {
                return Problem("Entity set is null.");
            }

            var regions = from m in _context.gWaterQuality.Include(g => g.Region)
            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                regions = regions.Where(s => s.Region.region_name!.Contains(searchString));
            }

            return View(await regions.ToListAsync());
        }

        // GET: gWaterQualities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.gWaterQuality == null)
            {
                return NotFound();
            }

            var gWaterQuality = await _context.gWaterQuality
                .Include(g => g.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gWaterQuality == null)
            {
                return NotFound();
            }

            return View(gWaterQuality);
        }

        // GET: gWaterQualities/Create
        public IActionResult Create()
        {
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID");
            return View();
        }

        // POST: gWaterQualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,regionID,collection_date,indicator,value,unit")] gWaterQuality gWaterQuality)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(gWaterQuality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", gWaterQuality.regionID);
            return View(gWaterQuality);
        }

        // GET: gWaterQualities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.gWaterQuality == null)
            {
                return NotFound();
            }

            var gWaterQuality = await _context.gWaterQuality.FindAsync(id);
            if (gWaterQuality == null)
            {
                return NotFound();
            }
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", gWaterQuality.regionID);
            return View(gWaterQuality);
        }

        // POST: gWaterQualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,regionID,collection_date,indicator,value,unit")] gWaterQuality gWaterQuality)
        {
            if (id != gWaterQuality.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(gWaterQuality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gWaterQualityExists(gWaterQuality.ID))
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
            ViewData["regionID"] = new SelectList(_context.regions, "regionID", "regionID", gWaterQuality.regionID);
            return View(gWaterQuality);
        }

        // GET: gWaterQualities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.gWaterQuality == null)
            {
                return NotFound();
            }

            var gWaterQuality = await _context.gWaterQuality
                .Include(g => g.Region)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gWaterQuality == null)
            {
                return NotFound();
            }

            return View(gWaterQuality);
        }

        // POST: gWaterQualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.gWaterQuality == null)
            {
                return Problem("Entity set 'AUCKPOLLWEBContextDb.gWaterQuality'  is null.");
            }
            var gWaterQuality = await _context.gWaterQuality.FindAsync(id);
            if (gWaterQuality != null)
            {
                _context.gWaterQuality.Remove(gWaterQuality);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gWaterQualityExists(int id)
        {
          return (_context.gWaterQuality?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
