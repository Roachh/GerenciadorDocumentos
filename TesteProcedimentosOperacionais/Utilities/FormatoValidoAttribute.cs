using System.ComponentModel.DataAnnotations;

namespace TesteProcedimentosOperacionais.Utilities
{
    public class FormatoValidoAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            string[] strings = ((IFormFile)value).FileName.Split(".");
            string extensao = (strings[strings.Length - 1]).ToLower();
            string[] extensoesValidas = { "pdf", "doc", "xls", "docx", "xlsx" };

            return extensoesValidas.Contains(extensao);

        }
    }
}
