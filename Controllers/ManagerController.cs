using Microsoft.AspNetCore.Mvc;
using AdAgency.Data;
using AdAgency.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AdAgency.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ManagerController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Просмотр категорий рекламы
        public IActionResult Categories()
        {
            var categories = _context.AdCategories.ToList();
            return View(categories);
        }

        // Добавить категорию
        [HttpPost]
        public async Task<IActionResult> AddCategory(AdCategory category)
        {
            _context.AdCategories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        // Удалить категорию
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.AdCategories.FindAsync(id);
            if (category == null) return NotFound();
            _context.AdCategories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Categories");
        }

        // Просмотр клиентов
        public IActionResult Clients()
        {
            var clients = _userManager.Users.Where(u => u.Role == "Client").ToList();
            return View(clients);
        }

        // Добавление заказа
        [HttpPost]
        public async Task<IActionResult> AddOrder(AdOrder order)
        {
            order.OrderStatus = "В обработке";
            _context.AdOrders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        // Удаление заказа
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.AdOrders.FindAsync(id);
            if (order == null) return NotFound();
            _context.AdOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Orders");
        }

        // Просмотр заявок
        public IActionResult Requests()
        {
            var requests = _context.Requests.ToList();
            return View(requests);
        }

        // Отклонение заявки
        public async Task<IActionResult> RejectRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) return NotFound();
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("Requests");
        }
    }
}