using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderSystem2024.Data;
using System.Runtime.InteropServices;

namespace OrderSystem2024.Controllers
{
    public class PermissionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PermissionController(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //aby dodać rolę Admin należy uruchomić tą metodę
        //https://localhost:7070/permission/AddRole
        public async Task<IActionResult> AddRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            _context.SaveChanges();
            return View();
        }
        ////aby przypisać rolę do użytkownika uruchamiamy poniższą metodę podając w linku email istniejącego w systmie użytkownika oraz nazwę roli
        //https://localhost:7070/permission/AssignRole?email=email@email.pl&role=Admin
        public async Task<IActionResult> AssignRole(string email, string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (!await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
            return View();
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AssignRoleByForm(string email, string role)
        {
            ViewData["CustomerUserId"] = new SelectList(_context.Users, "Email", "Email");
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "Name", "Name");
            if (email == null)
                return View();

            var user = await _userManager.FindByEmailAsync(email);
            if (!await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.AddToRoleAsync(user, role);
                ViewBag.Info = "Dodano rolę " + role + " do użytkownika " + email;
            }
            
            return View();
        }
    }
}
