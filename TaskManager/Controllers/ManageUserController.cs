using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class ManageUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
