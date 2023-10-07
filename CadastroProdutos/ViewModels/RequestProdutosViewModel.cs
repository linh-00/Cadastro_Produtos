using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.ViewModels
{
    public class RequestProdutosViewModel
    {
        [Required]
        public int Quantidade { get; set; }
    }
}
