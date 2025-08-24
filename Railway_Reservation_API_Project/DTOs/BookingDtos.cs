using System.ComponentModel.DataAnnotations;

namespace Railway_Reservation_API_Project.DTOs
{
    public class BookingCreateDto
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "PassengerId is required")]
        public int PassengerId { get; set; }

        [Required(ErrorMessage = "TrainId is required")]
        public int TrainId { get; set; }

        [Required(ErrorMessage = "Booking date is required")]
        public DateTime BookingDate { get; set; }
    }

    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int PassengerId { get; set; }
        public int TrainId { get; set; }
        public DateTime BookingDate { get; set; }
    }


}
