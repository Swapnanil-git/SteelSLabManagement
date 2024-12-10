using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Data;
using SteelSlabManagement.Models;

namespace SteelSlabManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Inventory.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory != null) _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
