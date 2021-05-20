﻿using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Repository.RepositoryFolder;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace AlejandroCep.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        private readonly IRepository _context;
        private readonly IMemoryCache _memoryCache;

        public MunicipiosController(IRepository repository, IMemoryCache memoryCache)
        {
            _context = repository;
            _memoryCache = memoryCache;
        }

        [HttpGet(nameof(Index))]
        [Authorize(Roles = "Desenvolvedor")]
        public IActionResult Index(int id)
        {
            var client = new WebClient();
            string json = client.DownloadString(@"https://servicodados.ibge.gov.br/api/v1/localidades/municipios");

            List<IbgeMunicipio> ibgeMunicipios = JsonSerializer.Deserialize<List<IbgeMunicipio>>(json);

            foreach (var cidade in ibgeMunicipios)
            {
                _context.SaveMunicipio(cidade);
            }

            return Ok("Items salvos com sucesso");
        }

        [HttpGet(nameof(GetMunicipio))]
        [AllowAnonymous]
        public IActionResult GetMunicipio(int id)
        {
            if (_memoryCache.TryGetValue(id, out object cidadeData))
            {
                return Ok(cidadeData);
            }
            else
            {
                var cidadeDados = _context.GetMunicipioByIbge(id);

                if (cidadeDados != null)
                {
                    var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                        SlidingExpiration = TimeSpan.FromSeconds(1200)
                    };
                    _memoryCache.Set(cidadeDados.id, cidadeDados);
                    return Ok(cidadeDados);
                }
                else
                    return BadRequest("Cidade não encontrada");
            }
        }
    }
}