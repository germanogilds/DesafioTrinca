using Churrasco.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Churrasco.Infra.Repository.Context
{
    public class EventoChurrascoContext : DbContext
    {
        public EventoChurrascoContext(DbContextOptions<EventoChurrascoContext> options) : base(options)
        {

        }

        public DbSet<EventoChurrasco> EventoChurrascos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
