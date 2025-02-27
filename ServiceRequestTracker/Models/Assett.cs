namespace ServiceRequestTracker.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public EquipmentType Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Make Manufacturer { get; set; }
        public Model Model { get; set; }

        public List<ServiceRequest> ServiceHistory { get; set; }
    }

    public class ItAsset : Asset
    {

    }

    public class HRAsset : Asset 
    { 
    
    }


    public enum EquipmentType
    {
        Desktop,
        Laptop,
        Projector,

    }

    public enum Make
    {
        Lenovo
    }

    public enum Model
    {
        G2
    } 
}
