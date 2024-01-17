using Microsoft.AspNetCore.Mvc;
using TesteDesenvolvimentoBeeviral.Models;

namespace TesteDesenvolvimentoBeeviral.Controllers
{
    public class HomeController : Controller
    {
        public static readonly List<Pessoa> Pessoas = new();

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculoFatorial([FromForm] string numero)
        {
            if (!string.IsNullOrEmpty(numero) && numero.All(char.IsDigit))
            {
                if (int.TryParse(numero, out int valor) && valor > 0)
                {
                    var resultado = 1;

                    for (int n = 1; n <= valor; n++)
                    {
                        resultado *= n;
                    }

                    ViewData["Numero"] = resultado;
                }
                else
                {
                    ViewData["Erro"] = "Digite um número inteiro não negativo e maior que zero!";
                }
            }
            else
            {
                ViewData["Erro"] = "Digite um número inteiro não negativo e maior que zero!";
            }

            return View(nameof(Index));
        }


        [HttpGet]
        public IActionResult CadastroPessoa()
        {
            if (Pessoas.Count > 0)
                ViewData["Pessoas"] = Pessoas.Where(x => x.Idade > 30).ToList();
            else
            {
                Pessoas.AddRange(new List<Pessoa>
                {
                    new ("Pessoa", 18, "Pessoa@gmail.com"),
                    new ("Pessoa1", 30, "Pessoa1@gmail.com"),
                    new ("Pessoa2", 31, "Pessoa2@gmail.com"),
                    new ("Pessoa3", 35, "Pessoa3@gmail.com"),
                    new ("Pessoa4", 45, "Pessoa4@gmail.com"),
                    new ("Pessoa5", 12, "Pessoa5@gmail.com"),
                    new ("Pessoa6", 15, "Pessoa6@gmail.com"),
                    new ("Pessoa7", 25, "Pessoa7@gmail.com"),
                    new ("Pessoa8", 29, "Pessoa8@gmail.com"),
                });

                ViewData["Pessoas"] = Pessoas.Where(x => x.Idade > 30).ToList();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastroEListaDePessoas([FromForm] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                Pessoas.Add(pessoa);

                ViewData["Pessoas"] = Pessoas.Where(x => x.Idade > 30).ToList();
            }

            return View(nameof(CadastroPessoa));
        }
    }
}
