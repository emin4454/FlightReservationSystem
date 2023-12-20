using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public TimeSpan worktimeStart { get; set; }
        public int worktimeLength { get; set; }
        public Branch branch { get; set; }
        public Policlinic policlinic { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
