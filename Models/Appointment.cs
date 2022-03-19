using System;
using System.ComponentModel.DataAnnotations;

namespace TempleTours.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        [Required]
        public int PartySize { get; set; }
    }
}
