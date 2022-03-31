using System;
using System.ComponentModel.DataAnnotations;

namespace TempleTours.Models
{
    public partial class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(25)]
        public string GroupName { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        [Required]
        [Range(1,50)] //Limit to 50 characters
        public int PartySize { get; set; }
    }
}
