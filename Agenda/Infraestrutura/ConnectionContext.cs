using Agenda.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=agenda.db;Cache=Shared");
    }
}
