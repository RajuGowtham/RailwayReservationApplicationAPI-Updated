using System.ComponentModel.DataAnnotations;

namespace Railway_Reservation_API_Project.DTOs
{
    public class TrainCreateDto
    {
        [Required(ErrorMessage = "Train name is required")]
        public string TrainName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Destination is required")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "Departure time is required")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public DateTime ArrivalTime { get; set; }
    }

    public class TrainResponseDto
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

}
