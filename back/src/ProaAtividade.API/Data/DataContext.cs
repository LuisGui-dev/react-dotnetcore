using Microsoft.EntityFrameworkCore;
using ProaAtividade.API.models;

namespace ProaAtividade.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Atividade> Atividades { get; set; }
    }
}