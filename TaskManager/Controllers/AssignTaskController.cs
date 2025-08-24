using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class AssignTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
