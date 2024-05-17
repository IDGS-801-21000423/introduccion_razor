using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Numerics;

namespace introduccion_razor.Pages
{
    public class SumatoriaModel : PageModel
    {

        [BindProperty]
        public double A {  get; set; }

        [BindProperty]
        public double B { get; set; }

        [BindProperty]
        public double X { get; set; }

        [BindProperty]
        public double Y { get; set; }

        [BindProperty]
        public int N { get; set; }
        public List<string> Results { get; private set; } = new List<string>();

        public void OnPost()
        {
            double sum = 0;
            for (int k = 0; k <= N; k++)
            {
                BigInteger combination = Combination(N, k);
                //double term = (double)Combination(N, k) * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                double term = (double) combination * Math.Pow(A * X, N - k) * Math.Pow(B * Y, k);
                sum += term;
                //Results.Add($"Cuando k = {k}, el termino es {term}");
                Results.Add($"Cuando k = {k}, la combinacion de {N} y {k} es {combination} y el termino es {term}");
            }
            Results.Add($"El resultado de la expresion es: {sum}");
        }
        public static BigInteger Factorial(int n)
        {
            BigInteger fact = 1;
            for(int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
        public static BigInteger Combination(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k)); 
        }
    }
}
