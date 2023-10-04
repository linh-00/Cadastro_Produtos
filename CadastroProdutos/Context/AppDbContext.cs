using CadastroProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite
            (connectionString:"DataSource=app.db;Cache=Shared");
    }
}
