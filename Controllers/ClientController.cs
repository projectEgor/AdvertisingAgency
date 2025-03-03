using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdvAgency.Data;
using AdvAgency.Models;
using AdvAgency.ViewModels;
using Microsoft.Extensions.Logging;

namespace AdvAgency.Controllers
{
    [Authorize(Roles = "User")]
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly ILogger<ClientController> _logger;

        public ClientController(AppDbContext context, UserManager<Users> userManager, ILogger<ClientController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> AdvertCategories()
        {
            var categories = await _context.AdvertCategories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _context.AdOrders
                .Include(o => o.AdvertCategory)
                .Where(o => o.UserId == user.Id)
                .ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> NewOrder()
        {
            ViewBag.AdvertCategories = await _context.AdvertCategories.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewOrder(NewOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var category = await _context.AdvertCategories.FindAsync(model.AdvertCategoryId);
                
                if (category == null)
                {
                    ModelState.AddModelError("", "Выбранная категория рекламы не найдена");
                    ViewBag.AdvertCategories = await _context.AdvertCategories.ToListAsync();
                    return View(model);
                }

                var order = new AdOrder
                {
                    UserId = user.Id,
                    AdvertCategoryId = model.AdvertCategoryId,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Status = "Новый",
                    TotalPrice = category.BasePrice
                };

                _context.AdOrders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyOrders));
            }

            ViewBag.AdvertCategories = await _context.AdvertCategories.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var order = await _context.AdOrders
                .Include(o => o.AdvertCategory)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);
            
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        
    }
} 