using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.TokenService;
using Service.UserService;
using System.Threading.Tasks;

namespace AlejandroCep.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private IUserService _userService;

        public HomeController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate(string email, string senha)
        {
            User user = _userService.GetUser(user => user.Email == email
                    && user.Password == senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos!" });
            string token = _tokenService.GenerateToken(user);
            user.Password = "";

            return Ok(new
            {
                user = user,
                token = token
            });
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

        //401: nao autorizado pq nao te conhece.
        //403: eu sei quem vc é só que o que voce ta tentando fazer oq vc nao pode.
    }
}
