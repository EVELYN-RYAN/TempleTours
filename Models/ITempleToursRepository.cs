using System.Linq;
using TempleTours.Models;

namespace TempleTours
{
    public interface ITempleToursRepository
    {
        IQueryable<Appointment> Appointments { get; }

        public void SaveAppointment(Appointment a);
        public void CreateAppointment(Appointment a);
        public void DeleteAppointment(Appointment a);
    }
}