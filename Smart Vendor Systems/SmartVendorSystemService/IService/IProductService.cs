using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;

namespace SmartVendorSystemService.IService
{
    public interface IProductService 
    {
       public IEnumerable<Product> GetProducts();

        Product createProduct(ProductCreateDto dto);

        Product getDatabyid(int id);

        Product deletedata(int id);

        Product UpdateProduct(int id, ProductupdateDto dto);
    }
}
