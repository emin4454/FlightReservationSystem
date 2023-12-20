using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userMail { get; set; }
        public string userPassword { get; set; }
        public string role{ get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
}
