using System.ComponentModel.DataAnnotations;
namespace HospitalAppointmentSystem.ViewModels
{
    public class DoctorView
    {
        [Required]
        public string doctorName { get; set; }
        [Required]
        public int branchId { get; set; }
    }
}
