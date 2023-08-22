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
    public class regionsController : Controller
    {
        private readonly AUCKPOLLWEBContextDb _context;

        public regionsController(AUCKPOLLWEBContextDb context)
        {
            _context = context;
        }

        // GET: regions
        public async Task<IActionResult> Index()
        {
              return _context.regions != null ? 
                          View(await _context.regions.ToListAsync()) :
                          Problem("Entity set 'AUCKPOLLWEBContextDb.regions'  is null.");
        }

        // GET: regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.regions == null)
            {
                return NotFound();
            }

            var regions = await _context.regions
                .FirstOrDefaultAsync(m => m.regionID == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // GET: regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("regionID,region_name,region_pop")] regions regions)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(regions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regions);
        }

        // GET: regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.regions == null)
            {
                return NotFound();
            }

            var regions = await _context.regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }
            return View(regions);
        }

        // POST: regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("regionID,region_name,region_pop")] regions regions)
        {
            if (id != regions.regionID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(regions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!regionsExists(regions.regionID))
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
            return View(regions);
        }

        // GET: regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.regions == null)
            {
                return NotFound();
            }

            var regions = await _context.regions
                .FirstOrDefaultAsync(m => m.regionID == id);
            if (regions == null)
            {
                return NotFound();
            }

            return View(regions);
        }

        // POST: regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.regions == null)
            {
                return Problem("Entity set 'AUCKPOLLWEBContextDb.regions'  is null.");
            }
            var regions = await _context.regions.FindAsync(id);
            if (regions != null)
            {
                _context.regions.Remove(regions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool regionsExists(int id)
        {
          return (_context.regions?.Any(e => e.regionID == id)).GetValueOrDefault();
        }
    }
}
