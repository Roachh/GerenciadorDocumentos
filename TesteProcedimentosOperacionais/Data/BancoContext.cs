using Microsoft.EntityFrameworkCore;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>().HasData(
                new Processo
                {
                    Id = 1,
                    Nome = "Processo 1"
                },
                new Processo
                {
                    Id = 2,
                    Nome = "Processo 2"
                },
                new Processo
                {
                    Id = 3,
                    Nome = "Processo 3"
                }
                );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Id = 1,
                    ProcessoId = 1,
                    Nome = "Categoria 1"
                },
                 new Categoria
                 {
                     Id = 2,
                     ProcessoId = 1,
                     Nome = "Categoria 2"
                 },
                  new Categoria
                  {
                      Id = 3,
                      ProcessoId = 2,
                      Nome = "Categoria 3"
                  },
                   new Categoria
                   {
                       Id = 4,
                       ProcessoId = 2,
                       Nome = "Categoria 4"
                   },
                new Categoria
                {
                    Id = 5,
                    ProcessoId = 3,
                    Nome = "Categoria 5"
                },
                new Categoria
                {
                    Id = 6,
                    ProcessoId = 3,
                    Nome = "Categoria 6"
                }
                );
        }
    }
}
