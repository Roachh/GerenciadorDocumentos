using System.ComponentModel.DataAnnotations;
using TesteProcedimentosOperacionais.Data;
using TesteProcedimentosOperacionais.Repositorio;

namespace TesteProcedimentosOperacionais.Utilities
{
    public class CodigoUnicoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (BancoContext)validationContext.GetService(typeof(BancoContext));
            var codigo = Convert.ToInt32(value);

            if (_context.Documentos.Any((doc) => doc.Codigo == codigo))
                return new ValidationResult("Código já cadastrado.");

            return ValidationResult.Success;

        }
    }
}
