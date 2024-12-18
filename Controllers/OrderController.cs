using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteelSlabManagement.Data;
using SteelSlabManagement.Models;
using System.Threading.Tasks;
using System.Linq;
namespace SteelSlabManagement.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
                return NotFound();

            var order = await _context.Orders.FindAsync(id);
            if (order == null) 
                return NotFound();

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                double density = 0;
                switch(order.Grade)
                {
                    case "A":
                      density = 7.7;
                      break;
                    case "B":
                      density = 7.0;
                      break;
                    case "C":
                      density = 6.5;
                      break;
                    default:
                      ModelState.AddModelError("Grade", "Invalid grade");
                      return View(order);
                }
                order.Weight = density * order.Length * order.Width * order.Quantity;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();

            var order = await _context.Orders.FindAsync(id);
            if (order == null) 
                return NotFound();

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderId) 
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId)) 
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
                return NotFound();

            var order = await _context.Orders.FindAsync(id);
            if (order == null) 
                return NotFound();

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper Method: Check if Order Exists
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
