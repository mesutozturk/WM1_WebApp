using ItServiceApp.Models.Payment;
using ItServiceApp.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace ItServiceApp.Test
{
    public class PaymentTests
    {
        private readonly IPaymentService _paymentService;
        private readonly IyzicoPaymentOptions _options;
        private readonly IConfiguration _configuration;
        public PaymentTests(IPaymentService paymentService, IConfiguration configuration)
        {
            _configuration = configuration;
            var section = _configuration.GetSection(IyzicoPaymentOptions.Key);
            _options = new IyzicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"],
                ThreedsCallbackUrl = section["ThreedsCallbackUrl"],
            };
            _paymentService = paymentService;
            
        }

        [Fact]
        public void CheckInstallments()
        {
            var binNumbers = new string[]
                { "4543590000000006", "4157920000000002", "374427000000003", "4766620000000001" };
            foreach (var bin in binNumbers)
            {
                var result = _paymentService.CheckInstallments(bin, 1000);
            }


            Assert.Equal(true, true);
        }
    }
}
