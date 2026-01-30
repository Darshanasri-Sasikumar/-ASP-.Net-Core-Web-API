
using Microsoft.AspNetCore.Mvc;
using Smart_Vendor_Systems.Data;
using Smart_Vendor_Systems.Models.Dtofiles;
using Smart_Vendor_Systems.Models.Entites;
using Smart_Vendor_Systems.Models.NewFolder;


namespace Smart_Vendor_Systems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext _dbContext)
        {
            _context = _dbContext;

        }

        [HttpGet]
        public IActionResult getVendor()
        {
            var vendor = _context.Vendor.ToList();
            return Ok(new
            {
                data = vendor,
                message = "Data Fetched Successfully",
                status = 200
            }
            );
        }
        [HttpPost]
        public IActionResult CreateVendor(VendorCreatedto dto)
        {

            var vendor = new Vendor
            {
                VendorName = dto.VendorName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow
            };
            _context.Vendor.Add(vendor);
            _context.SaveChanges();
            return Ok(new
            {
                data = vendor,
                message = "data created successfully",
                status = 200
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetVendorByid(int id)
        {
            var vendor = _context.Vendor.Find(id);
            return Ok(new
            {

                message = "The vendor Your Looking is :",
                data = vendor,
                status = 200
            });
        }

        [HttpPut]
        public IActionResult updateVendordetails(int id, VendorUpdatedto dto)
        { 
       
            var vendor = _context.Vendor.Find(id);
            if(vendor is null)
            {
                return NotFound();

            }
            vendor.VendorName = dto.VendorName;
            vendor.Email = dto.Email;
            vendor.PhoneNumber = dto.PhoneNumber;
            vendor.CreatedAt = dto.CreatedAt;
            _context.SaveChanges();
            return Ok(
                new
                {
                    data = vendor,
                    message = "data Updated successfully",
                    status = 200
                });
            

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteVendorbyId(int id)
        {
            var vendor = _context.Vendor.Find(id);
            _context.Vendor.Remove(vendor);
            _context.SaveChanges();
            return Ok(
                 new
                 {
                     data = vendor,
                     message = "data Deleted successfully",
                     status = 200
                 }
                );
        }

        [HttpDelete("delete-all")]
        public IActionResult DeleteAllVendors()
        {
            var vendors = _context.Vendor.ToList();

            if (!vendors.Any())
            {
                return NotFound(new
                {
                    message = "No vendors found to delete",
                    status = 404
                });
            }

            _context.Vendor.RemoveRange(vendors);
            _context.SaveChanges();

            return Ok(new
            {
                message = "All vendor data deleted successfully",
                status = 200
            });
        }




    }
}
