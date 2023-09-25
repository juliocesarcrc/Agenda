using Agenda.Model;

namespace Agenda.Infraestrutura
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Adicionar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }

        public void Editar(Contato contato)
        {
            _context.Contatos.Update(contato);
            _context.SaveChanges();
        }

        public void Remover(Contato contato)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }

        public IEnumerable<Contato> ObtenhaContatos()
        {
            return _context.Contatos.AsEnumerable();
        }
    }
}
