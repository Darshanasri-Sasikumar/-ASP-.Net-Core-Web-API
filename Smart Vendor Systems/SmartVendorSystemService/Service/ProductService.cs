using Microsoft.AspNetCore.Mvc;
using SmartVendorSystemData.Data;
using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;
using SmartVendorSystemService.IService;

namespace SmartVendorSystemService.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _Context;
        public ProductService(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public IEnumerable<Product> GetProducts()
        {
            var Product = _Context.Product.ToList();
            return Product;
        }

        public Product createProduct(ProductCreateDto dto)
        {
            var Product = new Product
            {
                VendorId = dto.VendorId,
                Product_name = dto.Product_name,
                Price = dto.Price,
                stock = dto.stock,
                CreatedAt = dto.CreatedAt

            };
            _Context.Product.Add(Product);
            _Context.SaveChanges();

            return Product;

        } 

        public Product getDatabyid(int id)
        {
            var Product = _Context.Product.Find(id);
            return (Product);
        }

        public Product deletedata(int id)
        {
            var Product = _Context.Product.Find(id);
            _Context.Product.Remove(Product);
            _Context.SaveChanges();
            return (Product);
        }

      public  Product UpdateProduct(int id, ProductupdateDto dto)
        {
            var Product = _Context.Product.Find(id);
            Product.Product_name = dto.Product_name;
            Product.Price = dto.Price;
            Product.stock = dto.stock;
            Product.CreatedAt = dto.CreatedAt;
            _Context.SaveChanges();
            return Product;
        }
       
    }
}
