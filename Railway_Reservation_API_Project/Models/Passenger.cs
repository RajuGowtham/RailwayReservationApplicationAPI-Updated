using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Reservation_API_Project.Models
{
    public class Passenger
    {
        //public enum Genders
        //{
        //    Male,Female,Others
        //}

        [Key]
        public int PassengerId { get; set; }
        public string FullName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Email cannot exceed 50 characters")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string ContactNumber { get; set; }

        public string Place { get; set; }


        // foreign Key relation with User
        [ForeignKey("User")]
        public int UserId { get; set; }
        // Navigation Property [1 to 1 relation with User]
        public User? User { get; set; }


        // Navigation Property [1 to many relation with Booking]
        public ICollection<Booking>? Bookings { get; set; }

    }
}
