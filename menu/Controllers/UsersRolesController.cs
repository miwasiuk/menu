using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using menu.Data;
using menu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace menu.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public UsersRolesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UsersRoles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UsersRoles.Include(u => u.Roles).Include(u => u.User).OrderBy(u=>u.Roles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsersRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsersRoles == null)
            {
                return NotFound();
            }

            var usersRoles = await _context.UsersRoles
                .Include(u => u.Roles)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersRoles == null)
            {
                return NotFound();
            }

            return View(usersRoles);
        }

        // GET: UsersRoles/Create
        public IActionResult Create()
        {
            ViewData["RolesId"] = new SelectList(_context.Role.Where(r=>r.Name != "Administrator"), "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: UsersRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RolesId,UserId")] UsersRoles usersRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FindAsync(usersRoles.UserId);
                var role = await _context.Role.FindAsync(usersRoles.RolesId);

                await _userManager.AddToRoleAsync(user, role.Name);

                _context.Add(usersRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolesId"] = new SelectList(_context.Role, "Id", "Id", usersRoles.RolesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usersRoles.UserId);
            return View(usersRoles);
        }

        // GET: UsersRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsersRoles == null)
            {
                return NotFound();
            }

            var usersRoles = await _context.UsersRoles
                .Include(u => u.Roles)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usersRoles == null)
            {
                return NotFound();
            }

            return View(usersRoles);
        }

        // POST: UsersRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsersRoles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UsersRoles'  is null.");
            }
            var usersRoles = await _context.UsersRoles.FindAsync(id);
            var role = await _context.Role.FindAsync(usersRoles.RolesId);
            if (usersRoles != null && role.Name != "Administrator")
            {
                var user = await _context.Users.FindAsync(usersRoles.UserId);

                await _userManager.RemoveFromRoleAsync(user, role.Name);

                _context.UsersRoles.Remove(usersRoles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersRolesExists(int id)
        {
          return _context.UsersRoles.Any(e => e.Id == id);
        }
    }
}
