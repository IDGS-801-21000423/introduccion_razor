using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
namespace introduccion_razor.Pages
{
    public class imcModel : PageModel
    {
        // Definimos propiedades
        // Vincular propiedades con campos del formulario con [BindProperty]
        [BindProperty]
        public string pesokg { get; set; } = "";
        [BindProperty]
        public string alturacm { get; set; } = "";
        public double imc;
        public void OnPost()
        {
            // Recibimos los datos
            double peso = double.Parse(pesokg);
            double altura = double.Parse(alturacm);


            if (peso > 10 && altura > 110)
            {
                double alturaConv = altura / 100;


                imc = peso / (alturaConv * alturaConv);
                ModelState.Clear();
            }
            else
            {
                imc = 0;
            }
        }
    }
}
