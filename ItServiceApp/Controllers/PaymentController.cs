using System;
using ItServiceApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            var result = _paymentService.CheckInstallments("4157920000000002", 1000);

            var binNumbers = new string[]
                { "4543590000000006", "4157920000000002", "374427000000003", "4766620000000001" };
            foreach (var bin in binNumbers)
            {
                var result2 = _paymentService.CheckInstallments(bin, 1000);
            }

            return View(result);
        }
        
    }
}
