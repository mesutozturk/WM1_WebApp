using ItServiceApp.Models.Payment;

namespace ItServiceApp.Services
{
    public interface IPaymentService
    {
        InstallmentModel CheckInstallments(string binNumber, decimal price);
        PaymentResponseModel Pay(PaymentModel model);
    }
}
