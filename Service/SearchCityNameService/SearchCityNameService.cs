using Domain.Models;
using Repository.RepositoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SearchCityNameService
{
    public class SearchCityNameService : ISearchCityNameService
    {
        private readonly IRepository context;

        public SearchCityNameService(IRepository repository)
        {
            context = repository;
        }
        public IbgeMunicipio GetMunicipioByIbgeId(int idIbge)
        {
            return context.GetMunicipioByIbge(idIbge);
        }
    }
}
