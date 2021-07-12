using System.ComponentModel.DataAnnotations;

namespace IdentificadorApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(10, 300, ErrorMessage = "O preço deve ser de no mínimo 10 Usd e no máximo 300 Usd")]
        public double Preco { get; set; }
    }
}
