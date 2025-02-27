namespace ServiceRequestTracker.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; private set; }
        public LocationType Type{ get; set; }
        public List<User> Administrators { get; set; } 
        
            
        //Navigational Properties
        public List<ServiceRequest> LocationRequests { get; set; }
        public List<User> Users { get; set; }

    }

    public enum LocationType
    {
        Office,
        Elementary,
        Secondary,
        Alternative
    }
}
