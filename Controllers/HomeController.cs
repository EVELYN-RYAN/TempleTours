using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TempleTours.Models;

namespace TempleTours.Controllers
{
    public class HomeController : Controller
    {
        private ITempleToursRepository repo;

        public HomeController(ITempleToursRepository temp) => repo = temp;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Appointments() => View();

        public IActionResult SignUp() => View();

        public IActionResult Form() => View();
    }
}
