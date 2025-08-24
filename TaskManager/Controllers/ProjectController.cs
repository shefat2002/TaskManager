using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
