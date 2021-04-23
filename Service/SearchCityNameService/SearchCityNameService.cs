using Domain.Models;
using Repository.RepositoryFolder;

namespace Service.SearchCityNameService
{
    public class SearchCityNameService : ISearchCityNameService
    {
        private readonly IRepository context;

        public SearchCityNameService(IRepository repository)
        {
            context = repository;
        }

        /// <summary>
        /// Busca dados pelo codigo Ibge da cidade.
        /// </summary>
        /// <param name="idIbge">Código Ibge</param>
        /// <returns></returns>
        public IbgeMunicipio GetMunicipioByIbgeId(int idIbge)
        {
            return context.GetMunicipioByIbge(idIbge);
        }
    }
}
