using System.Linq;
using TempleTours.Models;

namespace TempleTours
{
    public interface ITempleToursRepository
    {
        IQueryable<Appointment> Appointments { get; }
        //Declare the methods for interface appointments
        public void SaveAppointment(Appointment a);
        public void CreateAppointment(Appointment a);
        public void DeleteAppointment(Appointment a);
    }
}