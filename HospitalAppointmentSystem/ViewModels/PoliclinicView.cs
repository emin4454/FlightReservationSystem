using System.ComponentModel.DataAnnotations;
namespace HospitalAppointmentSystem.ViewModels
{
    public class PoliclinicView
    { 
        [Required]
        public string policlinicName { get; set; }
    }
}
