namespace Agenda.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public bool Administrador { get; set; }
        public string Role { get; set; }

        public Usuario()
        {
        }
        public Usuario(string login, string senha, string nome, bool administrador)
        {
            this.Login = login;
            this.Senha = senha;
            this.Nome = nome;
            this.Administrador = administrador;

        }
    }
}
