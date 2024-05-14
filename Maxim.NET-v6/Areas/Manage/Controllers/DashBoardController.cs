using Microsoft.AspNetCore.Mvc;

namespace Maxim.NET_v6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
