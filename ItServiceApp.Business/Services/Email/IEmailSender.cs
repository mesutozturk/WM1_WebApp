using System.Threading.Tasks;
using ItServiceApp.Core.ComplexTypes;

namespace ItServiceApp.Business.Services.Email
{
    public interface IEmailSender
    {
        Task SendAsync(EmailMessage message);
    }
}
