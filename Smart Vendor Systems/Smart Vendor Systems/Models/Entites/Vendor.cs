using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Smart_Vendor_Systems.Models.Entites
{
    [Index(nameof(Email), IsUnique = true)]
    public class Vendor
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string VendorName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = true;

        public  DateTime CreatedAt {get; set ;}


    }
}
