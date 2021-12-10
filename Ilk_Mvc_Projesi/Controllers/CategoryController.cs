﻿using System;
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

        //[HttpGet]
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
            var category = _context.Categories
                .Include(x => x.Products)
                .ThenInclude(x => x.OrderDetails)
                .ThenInclude(x => x.Order)
                .FirstOrDefault(x => x.CategoryId == id);

            var category2 = from cat in _context.Categories
                            join prod in _context.Products on cat.CategoryId equals prod.CategoryId
                            join odetail in _context.OrderDetails on prod.ProductId equals odetail.ProductId
                            where cat.CategoryId == id
                            select cat;

            var model = category2.FirstOrDefault();

            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            var category = new Category()
            {
                CategoryName = model.CategoryName,
                Description = model.Description
            };
            _context.Categories.Add(category);
            try
            {
                _context.SaveChanges();
                return RedirectToAction("Detail", new { id = category.CategoryId });
            }
            catch (Exception ex)
            {
                
            }
            return View();
        }
    }
}