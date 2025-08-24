using System.ComponentModel.DataAnnotations;

namespace Railway_Reservation_API_Project.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }

        [Required]
        public string TrainName { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int TotalSeats { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }

        // Navigation Property [1 to many relation with Booking][1 train can have mutiple bookings]
        public ICollection<Booking> Bookings { get; set; }

    }
}
