﻿using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.ViewModels
{
    public class CreateProdutoViewModel
    {
        
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }

}
