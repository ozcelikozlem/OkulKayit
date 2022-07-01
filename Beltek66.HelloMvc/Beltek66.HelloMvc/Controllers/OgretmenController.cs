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
    public class OgretmenController : Controller
    {
        private readonly OkulDbContext _context;

        public OgretmenController(OkulDbContext context)
        {
            _context = context;
        }

        // GET: Ogretmen
        public async Task<IActionResult> Index()
        {
            var okulDbContext = _context.Ogretmenler.Include(o => o.Bolum);
            return View(await okulDbContext.ToListAsync());
        }

        // GET: Ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.OgretmenId == id);


            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: Ogretmen/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumAd");
            return View();
        }

        // POST: Ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgretmenId,Ad,Soyad,BolumId,Yas")] Ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumAd", ogretmen.BolumId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumAd", ogretmen.BolumId);
            return View(ogretmen);
        }

        // POST: Ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgretmenId,Ad,Soyad,BolumId,Yas")] Ogretmen ogretmen)
        {
            if (id != ogretmen.OgretmenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretmenExists(ogretmen.OgretmenId))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumAd", ogretmen.BolumId);
            return View(ogretmen);
        }

        // GET: Ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.Ogretmenler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.OgretmenId == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: Ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretmen = await _context.Ogretmenler.FindAsync(id);
            _context.Ogretmenler.Remove(ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgretmenExists(int id)
        {
            return _context.Ogretmenler.Any(e => e.OgretmenId == id);
        }


        public async Task<IActionResult> Dersler(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Ogretmenler
                 .Include(s => s.OgretmenDers).ThenInclude(s => s.Ders)
                     .Where(s => s.OgretmenId == id)
                 .AsNoTracking()
                 .FirstOrDefaultAsync();

            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);

        }


    }
}
