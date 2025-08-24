using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class ManageRoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
