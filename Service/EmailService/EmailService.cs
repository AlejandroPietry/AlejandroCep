using Domain.Enum;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Repository.RepositoryPattern;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private IRepository<HtmlEmails> _htmlEmailRepository;
        private IMemoryCache _memoryCache;
        public EmailService(IConfiguration configuration, IRepository<HtmlEmails> htmlEmailRepository, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _htmlEmailRepository = htmlEmailRepository;
            _memoryCache = memoryCache;
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

        public Task SendRecoveryPassword(User user)
        {
            var urlrRecoveryPassword = new UrlRecoveryPassword
            {
                Guild = Guid.NewGuid().ToString(),
                IsActive = true,
                DateCreated = DateTime.Now,
                UserId = user.id
            };

            string htmlBody = GetHtmlEmail(TypeEmail.passwordRecovery).Html;
            htmlBody = htmlBody.Replace("%usename%", user.UserName);

            SendEmail("alejandrocep@alejandrocep.com", "alejandrocep@alejandrocep.com", user.Email, "Recuperação de senha",
                htmlBody);
            return new Task(null);
        }

        public HtmlEmails GetHtmlEmail(TypeEmail typeEmail)
        {
            if (_memoryCache.TryGetValue(typeEmail, out HtmlEmails htmlEmail))
                return htmlEmail;
            else
            {
                htmlEmail = _htmlEmailRepository.Get(x => x.TypeEmail == TypeEmail.passwordRecovery).FirstOrDefault();

                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1200),
                    SlidingExpiration = TimeSpan.FromSeconds(300)
                };
                _memoryCache.Set(htmlEmail.TypeEmail, htmlEmail, memoryCacheEntryOptions);
                return htmlEmail;
            }
        }
    }
}
