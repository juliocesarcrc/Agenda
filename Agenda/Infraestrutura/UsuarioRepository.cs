using Agenda.Model;

namespace Agenda.Infraestrutura
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public Usuario Login(string login, string senha)
        {
            return _context.Usuarios.AsEnumerable().First(user => user.Login == login && user.Senha == senha);
        }
    }
}
