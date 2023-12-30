using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.ViewModels
{  
    public class AppointmentView
    {
        public int doctorId;
        public int userId;
        public DateTime appointmentDate { get; set; }
        [Display(Name = "lol")]
        public int appointmentTime { get; set; } // 0--5
    }
}
