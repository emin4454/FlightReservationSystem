using System.ComponentModel.DataAnnotations;
namespace HospitalAppointmentSystem.ViewModels
{
    public class DoctorView
    {
        public int doctorId { get; set; }
        [Required]
        public string doctorName { get; set; }
        [Required]
        public int branchId { get; set; }
    }
}
