namespace Agenda.Model
{
    public interface IContatoRepository
    {
        void Adicionar(Contato contato);
        void Editar(Contato contato);
        void Remover(Contato contato);
        IEnumerable<Contato> ObtenhaContatos();
    }
}
