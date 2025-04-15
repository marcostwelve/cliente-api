using System.ComponentModel.DataAnnotations;
using apiClientes.Helpers;

namespace apiClientes.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O {0} precisa ser digitado")]
        public string Nome { get; set; }

        public TipoCliente TipoCliente { get; set; }

        [Required(ErrorMessage = "O {0} precisa ser digitado")]
        [MinLength(11, ErrorMessage = "O {0} precisa ter no mínimo 11 caracteres")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "A {0} precisa ser digitada")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O {0} precisa ser digitado")]
        public string Telefone { get; set; }
        public bool EstaAtivo { get; set; } = true;

    }
}
