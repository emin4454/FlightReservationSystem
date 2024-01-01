using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public DateTime appointmentDate { get; set; }
        public int appointmentTime { get; set; } // Burayi 0-5 arasi yapicaz bi guzelce dusunmek lazim
        [Required]
        public Doctor doctor { get; set; }
        [Required]
        public User user { get; set; }
    }
}
    