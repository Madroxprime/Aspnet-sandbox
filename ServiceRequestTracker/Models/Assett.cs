using System.ComponentModel.DataAnnotations;

namespace ServiceRequestTracker.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public EquipmentType Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Make Manufacturer { get; set; }
        public Model Model { get; set; }

        public List<ITServiceRequest> ServiceHistory { get; set; } = new List<ITServiceRequest>();
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
