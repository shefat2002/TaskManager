using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly TaskDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(TaskDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            var users = _dbContext.Employees.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee user)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Employees.AddAsync(user);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    string defaultPassword = $"{user.Name}@123Aa"; // Set a default password
                    var identityUser = new IdentityUser
                    {
                        UserName = user.Email,
                        Email = user.Email,
                        PhoneNumber = user.Phone                    
                        
                    };
                    var identityResult = await _userManager.CreateAsync(identityUser, defaultPassword);
                    if (identityResult.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(identityUser, "Employee");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create user in identity system.");
                        return View(user);
                    }
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Failed to create employee.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
            }
            return View(user);
        }

    }
}