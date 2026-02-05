
using Microsoft.AspNetCore.Mvc;
using SmartVendorSystemData.Data;
using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;
using SmartVendorSystemData.Models.NewFolder;
using SmartVendorSystemService.IService;


namespace Smart_Vendor_Systems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IVendorService _IVendor;

        public VendorController(ApplicationDbContext _dbContext,IVendorService IVendor)
        {
            _context = _dbContext;
            _IVendor = IVendor;
        }

        [HttpGet]     
        public IActionResult getVendor()
        {
            try
            {
                var vendor = _IVendor.GetAllData();
                return Ok(new
                {
                    data = vendor,
                    message = "data created successfully",
                    status = 200
                });
            }catch(Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpPost]
        public IActionResult CreateVendor(VendorCreatedto dto)
        {
            try
            {
                var vendor = _IVendor.createData(dto);
                return Ok(new
                {
                    data = vendor,
                    message = "data created successfully",
                    status = 200
                });

            }
            catch (Exception)
            {
                return StatusCode(500, "Something Went Wrong");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetVendorByid(int id)
        {
            var vendor = _IVendor.GetVendorByid(id);
            return Ok(
                new
                {
                    data = vendor,
                    message = "Data Listed Successfully",
                    status = 200
                });
        }

        [HttpPut]
        public IActionResult updateVendordetails(int id, VendorUpdatedto dto)
        {

            var vendor = _IVendor.update(id, dto);
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
            var vendor = _IVendor.delete(id);
            return Ok(new
            {
                data = vendor,
                message = "Data deleted!",
                status = 200
            });
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
