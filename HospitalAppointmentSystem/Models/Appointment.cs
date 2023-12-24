using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public DateTime appointmentDate { get; set; }
        public TimeSpan appointmentTime { get; set; }
        [Required]
        public Doctor doctor { get; set; }
        [Required]
        public User user { get; set; }
    }
}
