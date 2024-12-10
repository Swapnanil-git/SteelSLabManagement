using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Data;
using SteelSlabManagement.Models;

namespace SteelSlabManagement.Controllers
{
    public class ShippingController : Controller
    {
        private readonly AppDbContext _context;

        public ShippingController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Shipping.Include(s => s.Order).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Orders = _context.Orders.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipping);
        }
    }
}
