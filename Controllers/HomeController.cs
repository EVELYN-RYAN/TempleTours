using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public IActionResult Appointments()
        {

            var x = repo.Appointments.ToList();

            return View(x);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            var x = repo.Appointments.ToList();
            return View(x);
        }

        [HttpGet]
        public IActionResult Form(string date)
        {
            string myDate = (date[1] + "/" + date[5] + date[6] +"/"+ date[10] + date[11] + date[12] + date[13] + date[14] + date[15] + date[16]);
            ViewBag.Date = myDate;
            return View();
        }

        [HttpPost]
        public IActionResult Form(Appointment a)
        {
            if (ModelState.IsValid)
            {
                repo.CreateAppointment(a);

                return View("Confirmation", a);
            }
            else
            {
                return View();
            }
        }
    }
}

