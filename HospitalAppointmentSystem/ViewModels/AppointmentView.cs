using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.ViewModels
{  
    public class AppointmentView
    {
        public int doctorId { get; set; }
        public DateTime appointmentDate { get; set; } 
        public string appointmentTime { get; set; } // 0--5
    }
}
