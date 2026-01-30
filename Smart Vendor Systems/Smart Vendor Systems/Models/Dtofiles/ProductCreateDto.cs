namespace Smart_Vendor_Systems.Models.Dtofiles
{
    public class ProductCreateDto
    {
        public int VendorId { get; set; }
        public string Product_name { get; set; }
        public double Price { get; set; }
        public int stock { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
