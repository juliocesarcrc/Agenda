namespace Agenda.Model
{
    public interface IUsuarioRepository
    {
        Usuario Login(string usuario, string senha);
    }
}
