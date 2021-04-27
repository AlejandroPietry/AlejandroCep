using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class EmissaoController : ControllerBase
    {
        [Route("emitirnfe/{id}")]
        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public IActionResult EmitirNFe(int id)
        {
            return Ok(new
            {
                user = User.Identity.Name,
                idNfe = id,
                deuBoa = true
            });
        }
    }
}
