using System;
using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
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

        public IActionResult Detail(int? id)
        {
            var data = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.ProductId == id);
            if (data == null)
                return RedirectToAction(nameof(Index));

            var model = new ProductViewModel()
            {
                ProductId = data.ProductId,
                CategoryName = data.Category?.CategoryName,
                CategoryId = data.CategoryId,
                CompanyName = data.Supplier?.CompanyName,
                ProductName = data.ProductName,
                UnitPrice = data.UnitPrice,
                SupplierId = data.SupplierId
            };

            return View(model);
        }
    }
}