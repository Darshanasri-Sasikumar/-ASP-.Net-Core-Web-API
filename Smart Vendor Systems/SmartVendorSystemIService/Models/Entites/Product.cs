using System.ComponentModel.DataAnnotations.Schema;

namespace SmartVendorSystemData.Models.Entites
{
    public class Product
    {
        public int Id { get; set; }

        public required int VendorId { get; set; }
        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
        public string Product_name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public DateTime CreatedAt { get; set; }
       

    }
}
