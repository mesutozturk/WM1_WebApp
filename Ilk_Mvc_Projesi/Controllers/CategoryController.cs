using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NorthwindContext _context;

        public CategoryController(NorthwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Categories
                .Include(x => x.Products)
                .OrderBy(x => x.CategoryName)
                .ToList();
            //resharper
            return View(data);
        }

        public IActionResult Detail(int? id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }
    }
}