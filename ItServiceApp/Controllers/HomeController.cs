﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ItServiceApp.Data;
using ItServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly IMapper _mapper;

        public HomeController(MyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _dbContext.SubscriptionTypes
                .OrderBy(x => x.Price)
                .ToList()
                .Select(x => _mapper.Map<SubscriptionTypeViewModel>(x))
                .ToList();


            //var data = new List<SubscriptionTypeViewModel>();

            //var query = _dbContext.SubscriptionTypes
            //    .OrderBy(x => x.Price)
            //    .ToList();

            //foreach (var subscriptionType in query)
            //{
            //    var dataItem = _mapper.Map<SubscriptionTypeViewModel>(subscriptionType);
            //    data.Add(dataItem);
            //}

            return View(model);
        }
    }
}
