using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Service.SearchCityNameService;

namespace Service.CepService
{
    public class CepService : ICepService
    {
        private string urlCepAbertoApi = @"https://www.cepaberto.com/api/v3/cep?cep={0}";
        private string[] arrayTokens =
        {
            "Token token=97d9b8a32cdd35d6222eb938ba22ccda",
            "Token token=77fe6351de5454d64b7bb2c89d8d9151"
        };
        private readonly ISearchCityNameService _nameService;

        public CepService(ISearchCityNameService nameService)
        {
            _nameService = nameService;
        }

        public Cep GetCep(string numCep)
        {
            int i = new Random().Next(1);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization",arrayTokens[i]);


            HttpResponseMessage response = httpClient.GetAsync(string.Format(urlCepAbertoApi, numCep)).Result;

            if (response.IsSuccessStatusCode)
            {
                Cep dadosCep = JsonSerializer.Deserialize<Cep>(response.Content.ReadAsStringAsync().Result);
                dadosCep.cidade.nome = _nameService.GetMunicipioByIbgeId(int.Parse(dadosCep.cidade.ibge)).nome;

                return dadosCep;
            }
            else
                throw new Exception("Erro de autorizacao ao buscar pelo cep");
        }

        public bool CheckCep(string numCep)
        {
            return true;
        }
    }
}
