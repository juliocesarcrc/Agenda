using Agenda.Model;

namespace Agenda.Servicos
{
    public class ServicoDeContato
    {
        private readonly IContatoRepository _contatoRepository;
        public ServicoDeContato(IContatoRepository contatoRepository)
        {
            this._contatoRepository = contatoRepository;
        }

        public List<Contato> ObtenhaListaDeContatos()
        {
            return _contatoRepository.ObtenhaContatos().ToList();
        }
        public Contato ObtenhaContato(Guid id)
        {
            try
            {
                return _contatoRepository.ObtenhaContatos().First(cont => cont.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception("Falha ao obter contato!",ex);
            }
        }

        public void AdicionarContato(string nome, string numero, string email)
        {
            var contato = new Contato(nome, numero, email);
            contato.Id = Guid.NewGuid();

            _contatoRepository.Adicionar(contato);
        }

        public void EditarContato(Guid id, string nome, string numero, string email)
        {
            var contato = this.ObtenhaContato(id);

            contato.Nome = nome;
            contato.Numero = numero;
            contato.Email = email;

            _contatoRepository.Editar(contato);
        }

        public void RemoverContato(Guid id)
        {
            var contato = this.ObtenhaContato(id);

            _contatoRepository.Remover(contato);
        }
    }
}
