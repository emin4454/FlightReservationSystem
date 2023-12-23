using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class User : IdentityUser
    {
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string? role{ get; set; }
        public ICollection<Appointment>? appointments { get; set; }
    }
}
