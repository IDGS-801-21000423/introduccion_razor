using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace introduccion_razor.Pages
{  
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public int shift { get; set; }

        [BindProperty]
        public string message { get; set; } = "";
        public string result { get; private set; } = "";
        public void OnPost(string action)
        {
            if(action == "Cifrar" && shift != 0)
            {
                result = Cifrar(message, shift);
            }
            else if (action == "Descifrar" && shift != 0)
            {
                result = Descifrar(message, shift);
            }
            else if(shift <= 0)
            {
                result = "Resultado no valido";
            }
        }

        private string Cifrar(string message, int shift)
        {
            return ProcessMessage(message, shift);
        }
        private string Descifrar(string message, int shift)
        {
            return ProcessMessage(message, -shift);
        }

        private string ProcessMessage(string message, int shift)
        {
            char[] buffer = message.ToUpper().ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];

                if (char.IsLetter(letter))
                {
                    char d = (char)((letter + shift - 'A') % 26 + 'A');
                    buffer[i] = d < 'A' ? (char)(d + 26) : d;
                }
            }
            return new string (buffer);
        }
    }
}
