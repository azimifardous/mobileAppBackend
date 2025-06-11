namespace HrAppApi.Models
{
    public class HrRequest
    {
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty; // Leave, Training, Performance
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Pending"; // Approved / Pending / Rejected
    }
}
