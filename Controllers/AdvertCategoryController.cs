using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AdvAgency.Data;
using AdvAgency.Models;

namespace AdvAgency.Controllers
{
    [AllowAnonymous]
    public class AdvertCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public AdvertCategoryController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var categories = await _context.AdvertCategories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertCategory = await _context.AdvertCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertCategory == null)
            {
                return NotFound();
            }

            return View(advertCategory);
        }

        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,BasePrice")] AdvertCategory advertCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advertCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advertCategory);
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertCategory = await _context.AdvertCategories.FindAsync(id);
            if (advertCategory == null)
            {
                return NotFound();
            }
            return View(advertCategory);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,BasePrice")] AdvertCategory advertCategory)
        {
            if (id != advertCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advertCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertCategoryExists(advertCategory.Id))
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
            return View(advertCategory);
        }


        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertCategory = await _context.AdvertCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advertCategory == null)
            {
                return NotFound();
            }

            return View(advertCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertCategory = await _context.AdvertCategories.FindAsync(id);
            _context.AdvertCategories.Remove(advertCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvertCategoryExists(int id)
        {
            return _context.AdvertCategories.Any(e => e.Id == id);
        }
    }
} 