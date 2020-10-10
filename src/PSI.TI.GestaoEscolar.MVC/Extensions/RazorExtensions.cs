using Microsoft.AspNetCore.Mvc.Razor;

namespace PSI.TI.GestaoEscolar.MVC.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatarCpf(this RazorPage page, long cpf) => cpf.ToString(@"000\.000\.000\-00");
    }
}