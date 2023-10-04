using System;

namespace CadastroProdutos.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
