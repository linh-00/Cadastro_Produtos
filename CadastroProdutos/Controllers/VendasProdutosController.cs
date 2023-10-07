using CadastroProdutos.Context;
using CadastroProdutos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using CadastroProdutos.Model;

namespace CadastroProdutos.Controllers
{
    [ApiController]
    [Route("v1")]
    public class VendasProdutosController : ControllerBase
    {
       
        [HttpPut("vendas/{id}")]
        public async Task<IActionResult> PutByAsync(
            [FromServices] AppDbContext context,
            [FromBody] RequestProdutosViewModel model,
            [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

                if (produto == null)
                    return NotFound("Produto não encontrado");

                if (model.Quantidade > produto.Quantidade)
                    return NotFound("Quantidade indisponível");


                produto.Quantidade = (produto.Quantidade - model.Quantidade);

                context.SaveChanges();

                

                return Ok(produto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
    }
        
    }
}
