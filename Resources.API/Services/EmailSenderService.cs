using Resources.API.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public Task SendEmailAsync(EmailModel emailModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sending email to recipients: " + emailModel.To);
            if (!string.IsNullOrWhiteSpace(emailModel.CC))
            {
                sb.AppendLine("CC recipients: " + emailModel.CC);
            }

            sb.AppendLine("Subject: " + emailModel.Subject);
            sb.AppendLine("Body: " + emailModel.Body);

            Console.WriteLine(sb.ToString());

            return Task.CompletedTask;
        }
    }
}
