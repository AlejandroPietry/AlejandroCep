using Domain.Models;

namespace Service.CepService
{
    public interface ICepService
    {
        Cep GetCep(string numCep);
        bool CheckCep(string numCep);
    }
}
