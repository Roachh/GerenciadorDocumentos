﻿using Microsoft.EntityFrameworkCore;
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
        }
    }
}
