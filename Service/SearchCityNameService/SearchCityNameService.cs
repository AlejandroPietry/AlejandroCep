using Domain.Models;
using Repository.RepositoryPattern;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Service.SearchCityNameService
{
    public class SearchCityNameService : ISearchCityNameService
    {
        private readonly IRepository<IbgeMunicipio> _context;

        public SearchCityNameService(IRepository<IbgeMunicipio> context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca dados pelo codigo Ibge da cidade.
        /// </summary>
        /// <param name="idIbge">Código Ibge</param>
        /// <returns></returns>
        public IbgeMunicipio GetMunicipioByIbgeId(int idIbge)
        {
            Expression<Func<IbgeMunicipio, bool>> expression = x => x.Id == idIbge;
            var teste = _context.Get(x => x.Id == idIbge);
            return _context.Get(x => x.Id == idIbge).First();
        }
    }
}
