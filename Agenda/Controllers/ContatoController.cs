using Agenda.Model;
using Agenda.Servicos;
using Agenda.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/contatos")]
    public class ContatoController : ControllerBase
    {
        public ServicoDeContato ServicoDeContato { get; set; }

        private readonly ILogger<ContatoController> _logger;
        public ContatoController(ServicoDeContato servicoDeContato, ILogger<ContatoController> logger)
        {
            this.ServicoDeContato = servicoDeContato;
            this._logger = logger;

        }

        [HttpGet("/ListaDeContatos")]
        public IActionResult ObtenhaContatos()
        {
            var contatos = this.ServicoDeContato.ObtenhaListaDeContatos();
            return Ok(contatos);
        }

        [HttpGet("/DetalhesContato")]
        public IActionResult ObtenhaContato(Guid id)
        {
            var contato = this.ServicoDeContato.ObtenhaContato(id);
            return Ok(contato);
        }

        [HttpPost("/AdicionarContato")]
        public IActionResult AdicionarContato(ContatoViewModel contato)
        {
            this.ServicoDeContato.AdicionarContato(contato.Nome, contato.Numero, contato.Email);
            return Ok();
        }

        [HttpPost("/EditarContato")]
        public IActionResult EditarContato(Contato contato)
        {
            this.ServicoDeContato.EditarContato(contato.Id, contato.Nome, contato.Numero, contato.Email);
            return Ok();
        }

        [Authorize(Roles = "adm")]
        [HttpPost("/RemoverContato")]
        public IActionResult RemoverContato(Guid id)
        {
            this.ServicoDeContato.RemoverContato(id);
            return Ok();
        }
    }
}
