using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class Policlinic
    {
        public int policlinicId { get; set; }
        [Required]
        public string policlinicName { get; set; }
        [Required]
        public ICollection<Branch> branches { get; set; }
    }
}
