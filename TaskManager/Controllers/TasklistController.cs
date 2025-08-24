using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class TasklistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
