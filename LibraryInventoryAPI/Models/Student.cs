namespace LibraryInventoryAPI.Models
{
    public class Student
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentNumber { get; set; } // Unique student identifier
    }
}
