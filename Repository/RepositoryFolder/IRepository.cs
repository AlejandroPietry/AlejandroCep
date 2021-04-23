using Domain.Models;

namespace Repository.RepositoryFolder
{
    public interface IRepository
    {
        IbgeMunicipio GetMunicipioByIbge(int ibge);
        void SaveMunicipio(IbgeMunicipio ibgeMunicipio);
    }
}
