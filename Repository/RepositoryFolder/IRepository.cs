using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryFolder
{
    public interface IRepository
    {
        IbgeMunicipio GetMunicipioByIbge(int ibge);
        void SaveMunicipio(IbgeMunicipio ibgeMunicipio);
    }
}
