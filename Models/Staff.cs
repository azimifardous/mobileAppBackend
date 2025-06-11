namespace HrAppApi.Models
{
    public class Staff
    {
        public int Id { get; set; } // Auto-increment ID

        public string? Name { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; } // navigation property

        // Address object
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Country { get; set; }
    }
}
