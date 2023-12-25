using HospitalAppointmentSystem.Models;
using System.ComponentModel.DataAnnotations;
namespace HospitalAppointmentSystem.ViewModels
{
    public class BranchView
    {
        [Required]
        public string branchName { get; set; }
        [Required]
        public int policlinicId { get; set; }
    }
}
