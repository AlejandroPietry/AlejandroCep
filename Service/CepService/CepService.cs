using Domain.Models;
using Newtonsoft.Json;
using Service.SearchCityNameService;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Busca todos os dados relacionado com o Cep.
        /// </summary>
        /// <param name="numCep">Cep do endereço.</param>
        /// <returns></returns>
        public Cep GetCep(string numCep)
        {
            int i = new Random().Next(1);
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", arrayTokens[i]);

            HttpResponseMessage response = httpClient.GetAsync(string.Format(urlCepAbertoApi, numCep)).Result;

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    Cep dadosCep = JsonConvert.DeserializeObject<Cep>(response.Content.ReadAsStringAsync().Result);
                    dadosCep.cidade.nome = _nameService.GetMunicipioByIbgeId(int.Parse(dadosCep.cidade.ibge)).nome ?? dadosCep.cidade.nome;

                    return dadosCep;
                }
                else
                    throw new Exception("Erro de autorizacao ao buscar pelo cep");
            }
            catch(Exception e)
            {
                throw new Exception("Verifique o CEP  e tente novamente!");
            }

        }

        /// <summary>
        /// Verifica se o cep está em um formato válido.
        /// </summary>
        /// <param name="numCep">Cep para ser verificado.</param>
        /// <returns></returns>
        public bool CheckCep(string numCep)
        {
            numCep = Regex.Replace(numCep, @"\D", "");
            if (numCep.Length == 8)
                return true;
            else
                return false;
        }
    }
}
