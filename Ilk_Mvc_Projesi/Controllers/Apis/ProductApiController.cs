using System;
using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_Mvc_Projesi.Controllers.Apis
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _dbContext;

        public ProductApiController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün ekleme işlemi başarılı",
                    Model = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
