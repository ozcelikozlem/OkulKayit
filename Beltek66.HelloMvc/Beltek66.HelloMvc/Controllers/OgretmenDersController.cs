using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beltek66.HelloMvc.Models;

namespace Beltek66.HelloMvc.Controllers
{
    public class OgretmenDersController : Controller
    {
        private readonly OkulDbContext _context;

        public OgretmenDersController(OkulDbContext context)
        {
            _context = context;
        }

        // GET: OgretmenDers
        public async Task<IActionResult> Index()
        {
            var okulDbContext = _context.OgretmenDers.Include(o => o.Ders).Include(o => o.Ogretmen);
            return View(await okulDbContext.ToListAsync());
        }

        // GET: OgretmenDers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenDers = await _context.OgretmenDers
                .Include(o => o.Ders)
                .Include(o => o.Ogretmen)
                .FirstOrDefaultAsync(m => m.OgretmenDersId == id);
            if (ogretmenDers == null)
            {
                return NotFound();
            }

            return View(ogretmenDers);


        }

        // GET: OgretmenDers/Create
        public IActionResult Create()
        {
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "DersAd");
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "FullName");
            return View();
        }

        // POST: OgretmenDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgretmenDersId,OgretmenId,DersId")] OgretmenDers ogretmenDers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmenDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "DersAd", ogretmenDers.DersId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "FullName", ogretmenDers.OgretmenId);
            return View(ogretmenDers);
        }

        // GET: OgretmenDers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenDers = await _context.OgretmenDers.FindAsync(id);
            if (ogretmenDers == null)
            {
                return NotFound();
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "DersAd", ogretmenDers.DersId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "FullName", ogretmenDers.OgretmenId);
            return View(ogretmenDers);
        }

        // POST: OgretmenDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgretmenDersId,OgretmenId,DersId")] OgretmenDers ogretmenDers)
        {
            if (id != ogretmenDers.OgretmenDersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmenDers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenDersExists(ogretmenDers.OgretmenDersId))
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
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "DersAd", ogretmenDers.DersId);
            ViewData["OgretmenId"] = new SelectList(_context.Ogretmenler, "OgretmenId", "FullName", ogretmenDers.OgretmenId);
            return View(ogretmenDers);
        }

        // GET: OgretmenDers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmenDers = await _context.OgretmenDers
                .Include(o => o.Ders)
                .Include(o => o.Ogretmen)
                .FirstOrDefaultAsync(m => m.OgretmenDersId == id);
            if (ogretmenDers == null)
            {
                return NotFound();
            }

            return View(ogretmenDers);
        }

        // POST: OgretmenDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretmenDers = await _context.OgretmenDers.FindAsync(id);
            _context.OgretmenDers.Remove(ogretmenDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenDersExists(int id)
        {
            return _context.OgretmenDers.Any(e => e.OgretmenDersId == id);
        }
    }
}
