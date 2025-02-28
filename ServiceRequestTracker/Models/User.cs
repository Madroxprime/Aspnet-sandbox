using System.ComponentModel.DataAnnotations;

namespace ServiceRequestTracker.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? PhoneNumber { get; set; }

        // Navigational Properties
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<ServiceRequest> UserRequests { get; set; } = new List<ServiceRequest>();
    }
}
