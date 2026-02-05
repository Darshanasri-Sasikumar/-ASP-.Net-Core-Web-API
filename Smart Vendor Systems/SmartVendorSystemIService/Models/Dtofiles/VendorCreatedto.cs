using System.ComponentModel.DataAnnotations;

namespace SmartVendorSystemData.Models.NewFolder
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
