using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_Vendor_Systems.Data;
using Smart_Vendor_Systems.Models.Dtofiles;
using Smart_Vendor_Systems.Models.Entites;

namespace Smart_Vendor_Systems.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext dbcontext)
        {
            _context = dbcontext;
        }

        [HttpGet]
        public IActionResult GetProduts()
        {
            var product = _context.Product.ToList();
            return Ok(
                new
                {
                    Data = product,
                    message = "Product Listed Succesfull",
                    status = 200,
                });
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto dto)
        {
            var Product = new Product
            {
                VendorId = dto.VendorId,
                Product_name = dto.Product_name,
                Price = dto.Price,
                stock = dto.stock,
                CreatedAt = dto.CreatedAt

            };

            _context.Product.Add(Product);
            _context.SaveChanges();
            return Ok(new
            {
                data = Product,
                message = "Product Saved Successfully",
                status =200

            });

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDatabyId(int id)
        {
            var Product = _context.Product.Find(id);
            return Ok(new
            {
                Data = Product,
                Message = "Data Fetched successfully",
                StatusCode = 200
            }
                
                );
        }

        [HttpDelete]
        public IActionResult DeleteData(int id)
        {
            var Product = _context.Product.Find(id);
            _context.Product.Remove(Product);
            _context.SaveChanges();
            return Ok(new
            {
                Data = Product,
                Message = "Data Delete successfully",
                StatusCode = 200


            });



        }

        [HttpPut]
        public IActionResult update(int id, ProductupdateDto dto)
        {
            var Product = _context.Product.Find(id);
            if(Product == null)
            {
                return NotFound(new
                {
                    message = "Data not found"
                });
            }
            Product.Product_name = dto.Product_name;
            Product.Price = dto.Price;
            Product.stock = dto.stock;
            Product.CreatedAt = dto.CreatedAt;
            _context.SaveChanges();
            return Ok(new
            {
                Data = Product,
                Message = "Data Updated successfully",
                StatusCode = 200
            });

        }


    }



}
