﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SearchCityNameService
{
    public interface ISearchCityNameService
    {
        IbgeMunicipio GetMunicipioByIbgeId(int idIbge);
    }
}
