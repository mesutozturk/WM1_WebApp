using System;
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

        private int _pageSize = 10;
        public IActionResult Index(int? page = 1)
        {
            var model = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .OrderBy(x => x.Category.CategoryName)
                .ThenBy(x => x.ProductName)
                .Skip((page.GetValueOrDefault() - 1) * _pageSize)
                .Take(_pageSize)
                .ToList();

            //ViewBag.Categories = _dbContext.Categories.OrderBy(x => x.CategoryName).ToList();
            //ViewBag.Suppliers = _dbContext.Suppliers.OrderBy(x => x.CompanyName).ToList();

            ViewBag.Page = page.GetValueOrDefault(1);
            ViewBag.Limit = (int)Math.Ceiling(_dbContext.Products.Count() / (double)_pageSize);

            return View(model);
        }
    }
}
