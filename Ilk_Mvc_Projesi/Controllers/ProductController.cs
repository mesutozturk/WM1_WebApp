using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _dbContext;

        public ProductController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .OrderBy(x => x.Category.CategoryName)
                .ThenBy(x => x.ProductName)
                .ToList();

            ViewBag.Categories = _dbContext.Categories.OrderBy(x => x.CategoryName).ToList();
            ViewBag.Suppliers = _dbContext.Suppliers.OrderBy(x => x.CompanyName).ToList();

            return View(model);
        }
    }
}
