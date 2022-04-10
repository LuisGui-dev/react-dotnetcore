using Microsoft.EntityFrameworkCore;
using ProaAtividade.Domain.Entities;
using ProAtividade.Data.Mappings;

namespace ProaAtividade.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtividadeMap());
        }
    }
}