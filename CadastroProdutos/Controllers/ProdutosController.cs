using CadastroProdutos.Context;
using CadastroProdutos.Model;
using CadastroProdutos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Threading.Tasks;

namespace CadastroProdutos.CadastroProdutosController
{
    [ApiController]
    [Route("v1")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        [Route("produtos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var produtos = await context
                .Produtos
                .AsNoTracking()
                .ToListAsync();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {
            var produto = await context
                .Produtos
                .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == id);
            return produto == null
                ? NotFound()
                : Ok(produto);
        }

         
        [HttpPost("produtos")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateProdutoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = new Produto
            {
                DataCadastro = DateTime.Now,
                Quantidade = model.Quantidade,
                Descricao = model.Descricao,
            };
            try
            {
                await context.Produtos.AddAsync(produto);
                await context.SaveChangesAsync();
                return Created(uri: $"v1/produto/{produto.Id}", produto);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("produtos/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateProdutoViewModel model,
            [FromRoute] int id)

        {
            if (!ModelState.IsValid)
                return BadRequest();

            var produto = await context
                .Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return NotFound();

            try
            {
                produto.Quantidade = model.Quantidade;
                produto.Descricao = model.Descricao;

                context.Produtos.Update(produto);
                await context.SaveChangesAsync();
                return Ok(produto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
        [HttpDelete("produtos/{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id
            )
        {
            var produto = await context
                .Produtos
                .FirstOrDefaultAsync(x => x.Id == id);
             
            try
            {
                context.Produtos.Remove(produto);
                await context.SaveChangesAsync();

                return Ok("Produto removido com sucesso");
            }
            catch (Exception)
            { 
                return BadRequest();
            }
        }
    }
}
