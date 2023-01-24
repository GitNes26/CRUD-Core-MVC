using CRUD_Core_MVC.Models;
using CRUD_Core_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Core_MVC.Controllers
{
    public class UserTestController : Controller
    {
        private readonly DbCrudContext _context;

        public UserTestController(DbCrudContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Profiles"] = new SelectList(_context.Profiles, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Profiles"] = new SelectList(_context.Profiles, "Id", "Name", model.ProfileId);
                return View(model);
            }
            User user = new();
            user.Username = model.Username;
            user.Email = model.Email;
            user.Password = model.Password;
            user.ProfileId = model.ProfileId;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
