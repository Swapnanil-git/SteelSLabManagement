using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Data;
using SteelSlabManagement.Models;

namespace SteelSlabManagement.Controllers
{
    public class ProductionController : Controller
    {
        private readonly AppDbContext _context;

        public ProductionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Production.Include(p => p.Order).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Orders = _context.Orders.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Production production)
        {
            if (ModelState.IsValid)
            {
                _context.Add(production);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(production);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var production = await _context.Production.FindAsync(id);
            if (production != null) _context.Production.Remove(production);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
