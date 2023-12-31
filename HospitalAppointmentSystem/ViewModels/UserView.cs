namespace HospitalAppointmentSystem.ViewModels
{
    public class UserView
    {
        public string userId { get; set; }
        public string userName { get; set; }

        public string userLastName { get; set; }
        public string userEmail { get; set; }

        public ICollection<string> roles { get; set; }
    }
}
