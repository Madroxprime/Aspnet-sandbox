namespace ServiceRequestTracker.Models
{
    public class User
    {
        public int UserId {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Location> Locations { get; set; }
        public List<ServiceRequest> UserRequests { get; set; }
    }
}
