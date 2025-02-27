namespace ServiceRequestTracker.Models
{
    public abstract class ServiceRequest
    {
        //Fields every type of Service Request will have
        public int ServiceRequestId {  get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public required string Description {  get; set; }
        public Discriminator RequestType {  get; set; }
        public DateTime RequestDate {  get; set; }
        public Status RequstStatus {  get; set; }

        // Navigational properties
        public User Requester { get; set; }
        public Location RequestLocation { get; set; }

    }

    public class ITServiceRequest : ServiceRequest
    {
        public int? AssetId { get; set; }


        // Navigational
        public Asset? Asset { get; set; } // Not sure if this should be moved to the Parent Class.
    }

    public class HRServiceRequest : ServiceRequest
    {
        public string HrField { get; set; }

    }

    public class MaintanceRequest : ServiceRequest
    {
        public string MaintanceField { get; set; }
    }

    public enum Discriminator
    {
        IT,
        HR,
        Maintanance,

    }

    public enum Status
    {
        Unstarted,  // Waiting
        Started,    // Work has began
        Blocked,    // Delay in work
        Escalated,  // Original service provider unable to complete request
        Closed      // Request finished.
    }
}