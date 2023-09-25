using Agenda.Model;

namespace Agenda.Servicos
{
    public class ServicoDeUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ServicoDeUsuario(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public Usuario Login(string login, string senha)
        {
            return this._usuarioRepository.Login(login, senha);
        }
    }
}
