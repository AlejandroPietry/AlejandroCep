using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Service.CepService;
using System;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly ICepService _cepService;
        private IMemoryCache _memoryCache;
        private IDistributedCache _distributedCache;

        public CepController(ICepService cepService, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _cepService = cepService;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        [Route("{cep}")]
        [Authorize]
        public IActionResult Get(string cep)
        {
            try
            {
                if (_cepService.CheckCep(cep))
                {
                    if (_memoryCache.TryGetValue(cep, out Cep dadosCep))
                        return Ok(dadosCep);

                    dadosCep = _cepService.GetCep(cep);

                    MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1200),
                        SlidingExpiration = TimeSpan.FromSeconds(300)
                    };
                    _memoryCache.Set(dadosCep.cep, dadosCep);

                    return Ok(_cepService.GetCep(cep));
                }
                else
                    return BadRequest("Cep não no formato invalido");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("vaitafarel/{cep}")]
        public async Task<IActionResult> GetCepRedisCache(string cep)
        {
            var dadosCep = await _distributedCache.GetStringAsync(cep);

            if (!String.IsNullOrWhiteSpace(dadosCep))
            {
                return Ok(dadosCep);
            }
            else
            {
                var dadosCepObj = _cepService.GetCep(cep);
                await _distributedCache.SetStringAsync(dadosCepObj.cep, JsonConvert.SerializeObject(dadosCepObj));
                return Ok(dadosCepObj);
            }
        }
    }
}
