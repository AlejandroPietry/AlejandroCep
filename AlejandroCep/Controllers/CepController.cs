
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.CepService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;

        public CepController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet]
        [Route("Get/{numCep}")]
        public IActionResult Get(string numCep)
        {
            try
            {
                if (_cepService.CheckCep(numCep))
                    return Ok(_cepService.GetCep(numCep));
                else
                    return BadRequest("Cep não no formato invalido");
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
