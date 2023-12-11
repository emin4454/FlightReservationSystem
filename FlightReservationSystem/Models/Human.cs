using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.Models
{
    public class Human
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(0)]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public int age { get; set; }

        public string ders { get; set; }
    }
}