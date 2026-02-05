using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartVendorSystemData.Data;
using SmartVendorSystemData.Models.Dtofiles;
using SmartVendorSystemData.Models.Entites;
using SmartVendorSystemService.IService;

namespace Smart_Vendor_Systems.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductService _productservice;
        public ProductController(ApplicationDbContext dbcontext,IProductService productservice)
        {
            _context = dbcontext;
            _productservice = productservice;
        }

        [HttpGet]
        public IActionResult GetProduts()
        {
            try
            {
                var Products = _productservice.GetProducts();
                return Ok(new
                {
                    Product = Products,
                    message = "Product Acieved Successfully!!",
                    status = 200
                });

            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
            
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto dto)
        {
            var produtct = _productservice.createProduct(dto);
            
            return Ok(new
            {
                data = produtct,
                message = "Product Saved Successfully",
                status =200

            });

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDatabyId(int id)
        {
            var Product = _productservice.getDatabyid(id);
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
            var Product = _productservice.deletedata(id);
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

            var Product = _productservice.UpdateProduct(id, dto);
            return Ok(new
            {
                Data = Product,
                Message = "Data Updated successfully",
                StatusCode = 200
            });

        }


    }



}
