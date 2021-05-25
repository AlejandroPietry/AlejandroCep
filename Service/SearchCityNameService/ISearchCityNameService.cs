using Domain.Models;

namespace Service.SearchCityNameService
{
    public interface ISearchCityNameService
    {
        IbgeMunicipio GetMunicipioByIbgeId(int idIbge);
        void SalveMunicipio(IbgeMunicipio municipio);
    }
}
