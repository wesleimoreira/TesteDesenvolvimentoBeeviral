using System.ComponentModel.DataAnnotations;

namespace TesteDesenvolvimentoBeeviral.Models
{
    public class Pessoa
    {
        public Pessoa() { }
        public Pessoa(string nome, int idade, string email)
        {
            Nome = nome;
            Idade = idade;
            Email = email;
        }

        [Required(ErrorMessage = "O Nome e Obrigatório!")]
        public string Nome { get; set; } = default!;

        [Required(ErrorMessage = "A Idade e obrigatórioa!")]
        public int Idade { get; set; } = default!;

        [Required(ErrorMessage = "Email Obrigatório!")]
        [EmailAddress(ErrorMessage = "Digite um email valido!")]
        public string Email { get; set; } = default!;
    }
}
