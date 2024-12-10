using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Data;
using SteelSlabManagement.Models;

namespace SteelSlabManagement.Controllers
{
    public class QualityChecksController : Controller
    {
        private readonly AppDbContext _context;

        public QualityChecksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.QualityChecks.Include(q => q.Inventory).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Inventories = _context.Inventory.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QualityCheck qualityCheck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualityCheck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qualityCheck);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var qualityCheck = await _context.QualityChecks.FindAsync(id);
            if (qualityCheck != null) _context.QualityChecks.Remove(qualityCheck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
