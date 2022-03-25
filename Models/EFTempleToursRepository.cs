using System.Linq;
using TempleTours.Models;

namespace TempleTours
{
    internal class EFTempleToursRepository: ITempleToursRepository
    {
        private TempleToursContext context { get; set; }

        public EFTempleToursRepository(TempleToursContext temp)
        {
            context = temp;
        }
        public IQueryable<Appointment> Appointments => context.Appointments;

        public void SaveAppointment(Appointment a)
        {
            context.Update(a);
            context.SaveChanges();
        }

        public void CreateAppointment(Appointment a)
        {
            context.Add(a);
            context.SaveChanges();
        }

        public void DeleteAppointment(Appointment a)
        {
            context.Remove(a);
            context.SaveChanges();
        }
    }
}