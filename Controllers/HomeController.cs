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
            if (date.Length == 17)
            {
                var parameterDate = (date[1] + "/" + date[5] + date[6] + "/" + date[10] + date[11] + date[12] + date[13] + date[14] + date[15] + date[16]);
                DateTime myDate = DateTime.ParseExact(parameterDate, "M/dd/yy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                ViewBag.Date = myDate;
            }
            else
            {
                var parameterDate = date[1] + "/" + date[5] + date[6] + "/" + date[10] + date[11] + date[12] + date[13] + date[14] + date[15] + date[16] + "0";
                DateTime myDate = DateTime.ParseExact(parameterDate, "M/dd/yy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                ViewBag.Date = myDate;
            }
            
            
            return View();
        }

        [HttpPost]
        public IActionResult Form(Appointment a)
        {
            if (ModelState.IsValid)
            {
                if (a.AppointmentId > 0)
                {
                    repo.SaveAppointment(a);
                }
                else
                {
                    repo.CreateAppointment(a);
                }
                return View("Confirmation", a);
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int appointmentId)
        {
            var appointment = repo.Appointments
                 .Single(x => x.AppointmentId == appointmentId);

            return View("Form", appointment);
        }
        public IActionResult Delete(int appointmentId)
        {
            var appointment = repo.Appointments
                 .Single(x => x.AppointmentId == appointmentId);
            repo.DeleteAppointment(appointment);

            return RedirectToAction("Appointments");
        }
    }
}

