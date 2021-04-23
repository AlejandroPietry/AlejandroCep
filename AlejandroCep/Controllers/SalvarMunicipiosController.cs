using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.RepositoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalvarMunicipiosController : ControllerBase
    {
        private readonly IRepository context;

        public SalvarMunicipiosController(IRepository repository)
        {
            context = repository;
        }
        [HttpGet(nameof(Index))]
        public IActionResult Index(int id)
        {
            var client = new WebClient();
            string json = client.DownloadString(@"https://servicodados.ibge.gov.br/api/v1/localidades/municipios");

            List<IbgeMunicipio> ibgeMunicipios = JsonSerializer.Deserialize<List<IbgeMunicipio>>(json);

            foreach(var cidade in ibgeMunicipios)
            {
                context.SaveMunicipio(cidade);
            }

            return Ok("Items salvos com sucesso");
        }

        [HttpGet(nameof(GetMunicipio))]
        public IActionResult GetMunicipio(int id)
        {
            var cidadeDados = context.GetMunicipioByIbge(id);

            if (cidadeDados != null)
                return Ok(cidadeDados);
            else
                return BadRequest("Cidade não encontrada");
        }
    }
}
