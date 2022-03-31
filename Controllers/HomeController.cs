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
        //Contructor
        public HomeController(ITempleToursRepository temp) => repo = temp;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Appointments()
        {
            //send all appointments
            var x = repo.Appointments.ToList();

            return View(x);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            //Send appointments to check if exists
            var x = repo.Appointments.ToList();
            return View(x);
        }

        [HttpGet]
        public IActionResult Form(string date)
        {
            //date comes in a escaped format. See if month is single digit (ex 3/12/22) = 17
            //or if it's double digit (ex 12/12/22) = 18
            if (date.Length == 17)
            {
                //Parse the single digit not UTF-8 escaped parameter
                var parameterDate = (date[1] + "/" + date[5] + date[6] + "/" + date[10] + date[11] + date[12] + date[13] + date[14] + date[15] + date[16]);
                DateTime myDate = DateTime.ParseExact(parameterDate, "M/dd/yy H:mm", System.Globalization.CultureInfo.InvariantCulture);
                //Viewbag the date for condition checking
                ViewBag.Date = myDate;
            }
            else
            {
                //Parse the double digit not UTF-8 escaped parameter
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
                //if the appointment is new ID == 0
                if (a.AppointmentId > 0)
                {
                    repo.SaveAppointment(a);
                    return RedirectToAction("Appointments");
                }
                else
                {
                    repo.CreateAppointment(a);
                    return RedirectToAction("Confirmation");
                }
                
            }
            else
            { //return back to correctly enter
                return View();
            }
        }

        public IActionResult Edit(int appointmentId)
        {
            //Get the single recored that matches the parameter ID
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

        public IActionResult Confirmation() => View();
    }
}

