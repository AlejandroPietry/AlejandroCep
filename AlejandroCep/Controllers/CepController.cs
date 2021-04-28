using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.CepService;
using System;

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
        [Route("Get/{cep}")]
        [Authorize]
        public IActionResult Get(string cep)
        {
            try
            {
                if (_cepService.CheckCep(cep))
                    return Ok(_cepService.GetCep(cep));
                else
                    return BadRequest("Cep não no formato invalido");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
