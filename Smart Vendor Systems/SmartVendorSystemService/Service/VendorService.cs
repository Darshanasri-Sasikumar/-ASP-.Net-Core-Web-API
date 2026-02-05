using Microsoft.AspNetCore.Http.HttpResults;
using SmartVendorSystemData.Data;
using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;
using SmartVendorSystemData.Models.NewFolder;
using SmartVendorSystemService.IService;

namespace SmartVendorSystemService.Service
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDbContext _context;
        public VendorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vendor> GetAllData()
        {
            var result = _context.Vendor.ToList();
            return result; 
        }

        public Vendor createData(VendorCreatedto dtofile)
        {
            var vendor = new Vendor
            {
                VendorName = dtofile.VendorName,
                Email = dtofile.Email,
                PhoneNumber = dtofile.PhoneNumber,
                IsActive = dtofile.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _context.Vendor.Add(vendor);
            _context.SaveChanges();

            return vendor;
        }

        public Vendor GetVendorByid(int id)
        {
            var vendor = _context.Vendor.Find(id);
            return vendor;
        }




        //public Vendor delete(int id)
        //{
        //    var vendor = _context.Vendor.Find(id);
        //    _context.Vendor.Remove(vendor);
        //    _context.SaveChanges();
        //    return (vendor);
        //}

        public Vendor update(int id , VendorUpdatedto dto)
        {
            var vendor = _context.Vendor.Find(id);
            vendor.VendorName = dto.VendorName;
            vendor.PhoneNumber = dto.PhoneNumber;
            vendor.Email = dto.Email;
            vendor.IsActive = dto.IsActive;
            vendor.CreatedAt = dto.CreatedAt;
            _context.SaveChanges();
            return (vendor);


        }

        public Vendor delete(int id)
        {
            var vendor = _context.Vendor.Find(id);
          
            vendor.IsActive = false;
         
            _context.SaveChanges();
            return (vendor);


        }
    }
}
