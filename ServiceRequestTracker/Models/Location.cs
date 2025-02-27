using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceRequestTracker.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public required string LocationName { get; set; }
        public required string LocationDescription { get; set; }
        public LocationType Type{ get; set; }

        [NotMapped]
        public List<User> Administrators { get; set; } = new List<User>();
        
            
        //Navigational Properties
        public List<ITServiceRequest> LocationRequests { get; set; } = new List<ITServiceRequest>();
        public List<User> Users { get; set; } = new List<User>();

    }

    public enum LocationType
    {
        Office,
        Elementary,
        Secondary,
        Alternative
    }
}
