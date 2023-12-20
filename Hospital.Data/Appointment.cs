using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public class Appointment
    {
        public int appointmentId { get; set; }
        public DateTime appointmentDate { get; set; }
        public TimeSpan appointmentTime { get; set; }
        public Doctor doctor { get; set; }
        public User user { get; set; }
    }
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userMail { get; set; }
        public string userPassword { get; set; }
        public int isAdmin { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public TimeSpan worktimeStart { get; set; }
        public int worktimeLength { get; set; }
        public Branch branch { get; set; }
        public Policlinic policlinic { get; set; }
        public ICollection<Appointment> appointments { get; set; }
    }
    public class Branch
    {
        public int branchId { get; set; }
        [Required]
        public string? branchName { get; set; }
        public ICollection<Doctor>? doctors { get; set; }
    }
    public class Policlinic
    {
        public int policlinicId { get; set; }
        [Required]
        public string? policlinicName { get; set; }
        [Required]
        public ICollection<Doctor>? doctors { get; set; }
    }
}
