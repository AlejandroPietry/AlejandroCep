namespace Domain.Models
{
    public class Cep
    {
        public Cidade cidade { get; set; }
        public Estado estado { get; set; }
        public double altitude { get; set; }
        public string longitude { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string latitude { get; set; }
    }
    public class Cidade
    {
        public string ibge { get; set; }
        public string nome { get; set; }
        public int ddd { get; set; }
    }

    public class Estado
    {
        public string sigla { get; set; }
    }
}
