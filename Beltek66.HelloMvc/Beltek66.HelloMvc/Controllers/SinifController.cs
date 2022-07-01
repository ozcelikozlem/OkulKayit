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
    public class SinifController : Controller
    {
        private readonly OkulDbContext _context;

        public SinifController(OkulDbContext context)
        {
            _context = context;
        }

        // GET: Sinif
        public async Task<IActionResult> Index()
        {
            return View(await _context.Siniflar.ToListAsync());
        }

        // GET: Sinif/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Siniflar
                .FirstOrDefaultAsync(m => m.SinifId == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // GET: Sinif/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sinif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SinifId,SinifAd")] Sinif sinif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinif);
        }

        // GET: Sinif/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Siniflar.FindAsync(id);
            if (sinif == null)
            {
                return NotFound();
            }
            return View(sinif);
        }

        // POST: Sinif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SinifId,SinifAd")] Sinif sinif)
        {
            if (id != sinif.SinifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinifExists(sinif.SinifId))
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
            return View(sinif);
        }

        // GET: Sinif/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinif = await _context.Siniflar
                .FirstOrDefaultAsync(m => m.SinifId == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // POST: Sinif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sinif = await _context.Siniflar.FindAsync(id);
            _context.Siniflar.Remove(sinif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinifExists(int id)
        {
            return _context.Siniflar.Any(e => e.SinifId == id);
        }

        public async Task<IActionResult> Ogrenciler(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogr = await _context.Siniflar
                 .Include(s => s.Ogenciler)
                     .Where(s => s.SinifId == id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            if (ogr == null)
            {
                return NotFound();
            }
            return View(ogr);

        }



    }
}
