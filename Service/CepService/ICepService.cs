using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CepService
{
    public interface ICepService
    {
        Cep GetCep(string numCep);
        bool CheckCep(string numCep);
    }
}
