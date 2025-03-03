using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AdvAgency.Data;
using AdvAgency.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvAgency.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly AppDbContext _context;

        public ManagerController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.AdOrders.Include(o => o.AdvertCategory).ToListAsync();
            return View(orders);
        }
    }
}