namespace Domain.Models
{
    public class UrlRecoveryPassword : BaseEntity
    {
        public string Guild { get; set; }
        public int UserId { get; set; }
    }
}
