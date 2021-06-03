using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <param name="sender">Remetente.</param>
        /// <param name="from">Email de envio.</param>
        /// <param name="to">Para quem vamos enviar. Lista de emails separados por virgula.</param>
        /// <param name="subject">Assunto.</param>
        /// <param name="body">Corpo do email</param>
        public void SendEmail(string sender, string from, string to, string subject, string body)
        {
            #region Configurando Smtp
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.TargetName = _configuration.GetValue<string>("SmtpEmail:targetName");
            smtpClient.Host = _configuration.GetValue<string>("SmtpEmail:host");
            smtpClient.Port = _configuration.GetValue<int>("SmtpEmail:port");
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = 
                new NetworkCredential(_configuration.GetValue<string>("SmtpEmail:Credentials:username"),
                _configuration.GetValue<string>("SmtpEmail:Credentials:password"));
            #endregion

            #region Configurando Mensagem de email
            MailMessage mailMessage = new MailMessage();
            mailMessage.Sender = new MailAddress(sender, "sendeDisplayName");
            mailMessage.From = new MailAddress(from, "fromDisplayName");
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            #endregion

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch
            {
                throw;
            }          
        }

    }
}
