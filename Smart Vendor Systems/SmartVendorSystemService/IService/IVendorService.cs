using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;
using SmartVendorSystemData.Models.NewFolder;

namespace SmartVendorSystemService.IService
{
    public interface IVendorService
    {
        IEnumerable<Vendor> GetAllData();
        Vendor createData(VendorCreatedto dtofile);

        Vendor GetVendorByid(int id);

        Vendor delete(int id);

        Vendor update(int id, VendorUpdatedto dto);
    }
}
