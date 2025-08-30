using Microsoft.AspNetCore.Mvc;
using Tasklyne.Data;
using Tasklyne.Models;

namespace Tasklyne.Controllers;

public class ProjectController : Controller
{
    private readonly TaskDbContext _context;
    public ProjectController(TaskDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();
        return View(projects);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Project project)
    {
        _context.Projects.Add(project);
        var result = _context.SaveChanges();
        if(result > 0)
        {
            TempData["SuccessMsg"] = "Project created successfully!";
        }
        else
        {
            TempData["ErrorMsg"] = "Failed to create project.";
        }
        return RedirectToAction("Index");
    }
}
