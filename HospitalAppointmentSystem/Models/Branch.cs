using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Branch
    {
        public int branchId { get; set; }
        [Required]
        [Display(Name = "Brans")]
        public string branchName { get; set; }
        [Required]
        public Policlinic policlinic { get; set; }
        public ICollection<Doctor> doctors { get; set; }
    }
}
