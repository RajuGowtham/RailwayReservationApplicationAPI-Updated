namespace Railway_Reservation_API_Project.DTOs
{
    public class searchResultDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
