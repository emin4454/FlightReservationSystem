using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Branch
    {
        public int branchId { get; set; }
        [Required]
        public string? branchName { get; set; }
        public ICollection<Doctor>? doctors { get; set; }
    }
}
