using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccion_razor.Pages
{
    public class SumaNumerosModel : PageModel
    {
        // Definimos propiedades
        // Vincular propiedades con campos del formulario con [BindProperty]
        [BindProperty]
        public string num1 { get; set; } = "";
        [BindProperty]
        public string num2 { get; set; } = "";
        public double suma;

        public void OnPost()
        {
            // Recibimos los datos
            double numero1 = double.Parse(num1);
            double numero2 = double.Parse(num2);

            suma = numero1 + numero2;

            ModelState.Clear();
        }
    }
}
