using ItServiceApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ItServiceApp.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPaymentService, IyzicoPaymentService>();
        }
    }
}
