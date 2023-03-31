using APIUsingDapper.Models;

namespace APIUsingDapper.Models
{
    public class UserProfile
    {
        public Int64 UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? IsActive { get; set; }
        public string? IsDelete { get; set; }
    }
}

