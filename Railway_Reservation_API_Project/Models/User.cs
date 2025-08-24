using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Railway_Reservation_API_Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
       // [StringLength(20, MinimumLength = 3, ErrorMessage = "Username Must be more than 3 characters")]
        public string UserName { get; set; }

        [Required]
      //  [StringLength(20, MinimumLength = 8, ErrorMessage = "Passoword Must be between 8 to 20 characters")]
        public string? PasswordHash { get; set; }

        [Required]
        public string? Role { get; set; }

        // Navigation Proper [1 to 1 relation with Passenger]
        public Passenger? Passenger { get; set; } = null;
    }
}
