using Domain.Enum;

namespace Domain.Models
{
    public class HtmlEmails : BaseEntity
    {
        public TypeEmail TypeEmail { get; set; }
        public string Html { get; set; }
        public string DescricaoHtml { get; set; }
    }
}
