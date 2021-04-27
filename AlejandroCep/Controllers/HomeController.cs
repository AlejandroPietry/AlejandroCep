using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.RepositoryFolder;
using Service.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository _context;
        private readonly ITokenService _tokenService;

        public HomeController(IRepository repository, ITokenService tokenService)
        {
            _context = repository;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var ipadress = IpAdress();
            User user = _context.GetUser(model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos!" });

            LogLogin logLogin = _context.GetLogLogin(user.Id);

            if(logLogin is null || !logLogin.IsActive())
            {
                var token = _tokenService.GenerateToken(user);
                _context.SetLogLogin(user.Id);
                user.Password = "";

                return new
                {
                    user = user,
                    token = token
                };
            }

            return BadRequest(new {message = "Usuário ja esta logado" });
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public void LogOut()
        {
            string userId = User.Claims.First(x => x.Type == ClaimTypes.SerialNumber).Value;
            _context.DeleteLogLogin(int.Parse(userId));
        }



        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "Desenvolvedor,Gerente")]
        public string Employee() => "gerente ou desenvolvedor.";


        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "Cliente")]
        public string Cliente() => "somente cliente";


        private string IpAdress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
