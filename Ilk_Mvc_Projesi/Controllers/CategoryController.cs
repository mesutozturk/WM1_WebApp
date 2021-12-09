using System.Linq;
using Ilk_Mvc_Projesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var context = new NorthwindContext();
            var data = context.Categories
                .OrderBy(x=>x.CategoryName)
                .ToList();
            //resharper
            return View(data);
        }
    }
}