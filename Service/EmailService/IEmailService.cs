namespace Service.EmailService
{
    public interface IEmailService
    {
        /// <param name="sender">Remetente.</param>
        /// <param name="from">Email de envio.</param>
        /// <param name="to">Para quem vamos enviar. Lista de emails separados por virgula.</param>
        /// <param name="subject">Assunto.</param>
        /// <param name="body">Corpo do email</param>
        void SendEmail(string sender, string from, string to, string subject, string body);
    }
}
