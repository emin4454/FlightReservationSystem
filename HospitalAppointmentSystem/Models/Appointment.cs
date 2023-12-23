using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public DateTime appointmentDate { get; set; }
        public TimeSpan appointmentTime { get; set; }
        public Doctor? doctor { get; set; }
        public User? user { get; set; }
    }
}
