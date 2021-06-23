using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.EmailService;
using Service.RecoveryPasswordService.cs;
using Service.TokenService;
using Service.UserService;
using System;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IRecoveryPasswordService _recoveryPasswordService;

        public HomeController(ITokenService tokenService, IUserService userService, IEmailService emailService, IRecoveryPasswordService recoveryPasswordService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _emailService = emailService;
            _recoveryPasswordService = recoveryPasswordService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate(string email, string senha)
        {
            User user = _userService.GetUser(user => user.Email == email
                    && user.Password == senha && user.IsActive == true);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos!" });
            string token = _tokenService.GenerateToken(user);
            user.Password = "";
            user.Email = "";

            return Ok(new
            {
                user = user,
                token = token
            });
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest(new { message = "Erro ao cadastrar o usuario, verifique os dados!" });

            _userService.CreateUser(user);
            return Ok(new { message = "Usuário criado com sucesso!" });
        }


        [HttpPost]
        [Route("recovery-password")]
        [AllowAnonymous]
        public async void RecoveryPassword(string email)
        {
            User user = _userService.GetUser(user => user.Email == email && user.IsActive == true);

            if (user is null)
                return;

            _emailService.SendRecoveryPassword(user);
        }

        //401: nao autorizado pq nao te conhece.
        //403: eu sei quem vc é só que o que voce ta tentando fazer oq vc nao pode.
    }
}
