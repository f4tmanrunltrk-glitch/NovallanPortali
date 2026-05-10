using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovallanPortali.Data;
using NovallanPortali.Models;

namespace NovallanPortali.Controllers
{
    public class IlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ilans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ilanlar.Include(i => i.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ilans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilanlar
                .Include(i => i.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }

            return View(ilan);
        }

        // GET: Ilans/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Ad");
            return View();
        }

        // POST: Ilans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Fiyat,ResimYolu,Sehir,Ilce,KategoriId,KullaniciId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Ad", ilan.KategoriId);
            return View(ilan);
        }

        // GET: Ilans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilanlar.FindAsync(id);
            if (ilan == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Ad", ilan.KategoriId);
            return View(ilan);
        }

        // POST: Ilans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fiyat,ResimYolu,Sehir,Ilce,KategoriId,KullaniciId")] Ilan ilan)
        {
            if (id != ilan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlanExists(ilan.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "Ad", ilan.KategoriId);
            return View(ilan);
        }

        // GET: Ilans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilan = await _context.Ilanlar
                .Include(i => i.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilan == null)
            {
                return NotFound();
            }

            return View(ilan);
        }

        // POST: Ilans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilan = await _context.Ilanlar.FindAsync(id);
            if (ilan != null)
            {
                _context.Ilanlar.Remove(ilan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlanExists(int id)
        {
            return _context.Ilanlar.Any(e => e.Id == id);
        }
    }
}
