using Maxim.NET_v6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maxim.NET_v6.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}