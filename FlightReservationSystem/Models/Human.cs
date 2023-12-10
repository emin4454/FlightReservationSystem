using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem.Models
{
    public class Human
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [MinLength(0)]
        [MaxLength(100)]
        [Required]
        public int age;
    }
}
