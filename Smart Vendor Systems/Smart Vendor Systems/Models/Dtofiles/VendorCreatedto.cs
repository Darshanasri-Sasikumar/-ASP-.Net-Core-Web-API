using System.ComponentModel.DataAnnotations;

namespace Smart_Vendor_Systems.Models.NewFolder
{
    public class VendorCreatedto
    {
        public string VendorName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

    }
}
