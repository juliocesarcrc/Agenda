using System.ComponentModel.DataAnnotations;

namespace Agenda.Model
{
    public class Contato
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string numero, string email)
        {
            this.Nome = nome;
            this.Numero = numero;
            this.Email = email;
        }
    }
}
