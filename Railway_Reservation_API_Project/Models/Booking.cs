using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Railway_Reservation_API_Project.Models
{
    public class Booking
    {
        //public enum BookingStatus
        //{
        //    Confirmed,
        //    Cancelled,
        //    Pending
        //}

        [Key]
        public int BookingId { get; set; }

        // Foreign Key relation with Passenger
        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }

        // Foreign Key relation with Train
        [ForeignKey("Train")]
        public int TrainId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; } // GETDATE() - use in fluentAPI

        public int seatsBooked { get; set; }
        public string Status { get; set; }
        
        // Navigation Property [1 to 1 relation with Passenger]
        public Passenger Passenger { get; set; }

        // Navigation Property [1 to 1 relation with Train]
        public Train Train { get; set; }


    }
}
