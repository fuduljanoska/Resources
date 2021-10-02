using Resources.API.Models;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(EmailModel emailModel);
    }
}
