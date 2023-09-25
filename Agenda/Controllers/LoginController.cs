using Agenda.Model;
using Agenda.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("/Login")]
    public class LoginController : Controller
    {
        public ServicoDeUsuario ServicoDeUsuario { get; set; }
        public ServicoDeToken ServicoDeToken { get; set; }

        public LoginController(ServicoDeUsuario servicoDeUsuario, ServicoDeToken servicoDeToken)
        {
            this.ServicoDeUsuario = servicoDeUsuario;
            this.ServicoDeToken = servicoDeToken;
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            try
            {
                var usuario = ServicoDeUsuario.Login(login, senha);
                var token = ServicoDeToken.GenerateToken(usuario);

                return Ok(token);
            }
            catch
            {
#if DEBUG
                if(login == "adm" && senha == "adm")
                {
                    var usuario = new Usuario(login, senha, "administrador", true);
                    usuario.Role = "adm";
                    var token = ServicoDeToken.GenerateToken(usuario);
                    return Ok(token);
                }
                else if (login == "usr" && senha == "usr")
                {
                    var usuario = new Usuario(login, senha,"usuário", false);
                    usuario.Role = "usr";
                    var token = ServicoDeToken.GenerateToken(usuario);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Usuário ou Senha Inválida");
                }
#endif

            }
        }
    }
}
