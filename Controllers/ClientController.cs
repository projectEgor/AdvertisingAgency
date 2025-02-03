using Microsoft.AspNetCore.Mvc;
using AdAgency.Data;
using AdAgency.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AdAgency.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ClientController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Просмотр каталога рекламы
        public IActionResult Categories()
        {
            var categories = _context.AdCategories.ToList();
            return View(categories);
        }

        // Отправить заявку
        [HttpPost]
        public async Task<IActionResult> SendRequest(int clientId)
        {
            var request = new OrderRequest
            {
                ClientId = clientId,
                RequestDate = DateTime.Now,
                RequestStatus = "На рассмотрении"
            };
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return RedirectToAction("Requests", new { clientId });
        }

        // Просмотр своих заявок
        public IActionResult Requests(int clientId)
        {
            var requests = _context.Requests.Where(r => r.ClientId == clientId).ToList();
            return View(requests);
        }
    }
}
