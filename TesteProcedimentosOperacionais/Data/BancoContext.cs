using Microsoft.EntityFrameworkCore;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<DocumentoModel> Documentos { get; set; }
        public DbSet<ProcessoModel> Processos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessoModel>().HasData(
                new ProcessoModel
                {
                    Id = 1,
                    Nome = "Processo 1"
                },
                new ProcessoModel
                {
                    Id = 2,
                    Nome = "Processo 2"
                },
                new ProcessoModel
                {
                    Id = 3,
                    Nome = "Processo 3"
                }
                );
        }
    }
}
