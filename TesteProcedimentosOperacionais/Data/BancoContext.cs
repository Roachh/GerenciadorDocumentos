using Microsoft.EntityFrameworkCore;
using TesteProcedimentosOperacionais.Models;

namespace TesteProcedimentosOperacionais.Data
{
    public class BancoContext : DbContext
    {
        public  BancoContext(DbContextOptions<BancoContext> options) : base (options)
        {

        }

        public DbSet<DocumentoModel> Documentos { get; set; }
    }
}
