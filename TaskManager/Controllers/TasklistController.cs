using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasklyne.Data;
using Tasklyne.Models;

namespace Tasklyne.Controllers;

public class TasklistController : Controller
{
    private readonly TaskDbContext _context;
    public TasklistController(TaskDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var tasklists = _context.Tasklists.ToList();
        return View(tasklists);
    }
    public IActionResult Create()
    {
        var model = new Tasklist
        {
            CreatedAt = DateTime.Now,
            IsCompleted = false,
            ProjectList = _context.Projects.OrderBy(o => o.Name).ToList()

        };

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Tasklist tasklist, List<int> Projectlist)
    {

        var result = 0;
        if(ModelState.IsValid)
        {
            if(Projectlist != null && Projectlist.Count > 0)
            {
                foreach (var projectId in Projectlist)
                {
                    var addnew = new Tasklist
                    {
                        CreatedAt = tasklist.CreatedAt,
                    };
                    var project = _context.Projects.Find(projectId);
                    if (project != null)
                    {
                        addnew.Project = project;
                        addnew.ProjectId = project.Id;
                    }
                    _context.Tasklists.Add(addnew);

                }
            }
            result = _context.SaveChanges();
            if(result > 0)
            {
                TempData["SuccessMsg"] = "Task created successfully!";
            }
            else
            {
                TempData["ErrorMsg"] = "Failed to create task.";
            }
            return RedirectToAction("Index");
        }
        return View(tasklist);
    }

}
