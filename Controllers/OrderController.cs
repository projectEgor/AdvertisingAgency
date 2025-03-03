using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AdvAgency.Data;
using AdvAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvAgency.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AllOrders()
        {
            var orders = await _context.AdOrders.Include(o => o.AdvertCategory).ToListAsync();
            return View(orders);
        }

        
        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.AdOrders
                .Include(o => o.AdvertCategory)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        
        public IActionResult Create()
        {
            ViewBag.AdvertCategories = new SelectList(_context.AdvertCategories, "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdvertCategoryId,Description,StartDate,EndDate,Status,TotalPrice")] AdOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AdvertCategories = new SelectList(_context.AdvertCategories, "Id", "Name", order.AdvertCategoryId);
            return View(order);
        }


        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.AdOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var advertCategories = await _context.AdvertCategories.ToListAsync();
            ViewBag.AdvertCategories = advertCategories;

            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(int id, [Bind("Id,AdvertCategoryId,Description,StartDate,EndDate,Status,TotalPrice")] AdOrder order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewBag.AdvertCategories = new SelectList(_context.AdvertCategories, "Id", "Name", order.AdvertCategoryId);
            return View(order);
        }

       
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.AdOrders
                .Include(o => o.AdvertCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrderConfirmed(int id)
        {
            var order = await _context.AdOrders.FindAsync(id);
            _context.AdOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.AdOrders.Any(e => e.Id == id);
        }
    }
}