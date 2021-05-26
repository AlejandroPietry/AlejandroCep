using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.RepositoryPattern;
using Service.TokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.WebSockets;
using Service.UserService;

namespace AlejandroCep.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<User> _context;
        private readonly ITokenService _tokenService;
        private IUserService _userService;

        public HomeController(IRepository<User> repository, ITokenService tokenService, IUserService userService)
        {
            _context = repository;
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(string email, string senha)
        {
            User user = _userService.GetUser(user => user.Email == email
                    && user.Password == senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos!" });
            string token = _tokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest(new { message = "Erro ao cadastrar o usuario, verifique os dados!" });

            _userService.CreateUser(user);
            return Ok(new { message = "Usuário criado com sucesso!" });
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
        //401: nao autorizado pq nao te conhece.
        //403: eu sei quem vc é só que o que voce ta tentando fazer oq vc nao pode.
    }
}
