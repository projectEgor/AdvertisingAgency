using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AdAgency.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AdAgency.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Просмотр списка менеджеров
        public IActionResult Managers()
        {
            var managers = _userManager.Users.Where(u => u.Role == "Manager").ToList();
            return View(managers);
        }

        // Добавление менеджера
        [HttpPost]
        public async Task<IActionResult> AddManager(User user)
        {
            user.Role = "Manager";
            var result = await _userManager.CreateAsync(user, "DefaultPassword123!");
            if (result.Succeeded)
                return RedirectToAction("Managers");
            return BadRequest(result.Errors);
        }

        // Удаление менеджера
        public async Task<IActionResult> DeleteManager(string id)
        {
            var manager = await _userManager.FindByIdAsync(id);
            if (manager == null) return NotFound();
            await _userManager.DeleteAsync(manager);
            return RedirectToAction("Managers");
        }

        // Просмотр всех учетных записей
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Удаление учетной записи
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Users");
        }
    }
}