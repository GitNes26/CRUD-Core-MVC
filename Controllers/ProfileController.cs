using CRUD_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Core_MVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DbCrudContext _context;

        public ProfileController(DbCrudContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Profile> list = new();
            list = await _context.Profiles.ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //para validar que solo se hagan peticiones desde mi dominio
        public async Task<IActionResult> Create(Profile model)
        {
            if (!ModelState.IsValid) return View(model);

            Profile profile = new();
            profile = model;
            profile.Menus = profile.Menus ?? DBNull.Value.ToString();
            _context.Add(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        
        
        {
            var profile = await _context.Profiles.FindAsync(id);
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(Profile model)
        {
            if (!ModelState.IsValid) return View(model);

            Profile profile = new();
            profile = model;
            _context.Entry("Profiles");
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
