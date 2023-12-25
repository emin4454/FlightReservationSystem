using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }

        public String availableAppointmentTimes { get; set; }
        public Branch branch { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
