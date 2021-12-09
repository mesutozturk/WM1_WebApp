using Microsoft.AspNetCore.Mvc;

namespace Ilk_Mvc_Projesi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}