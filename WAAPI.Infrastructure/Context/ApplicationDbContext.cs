using Microsoft.EntityFrameworkCore;
using WAAPI.Domain.Entities;

namespace WAAPI.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){

        }
        
        public DbSet<User>? Users{ get; set; }
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Equipe>? Equipes { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<PedidoProduto>? PedidoProduto { get; set; }

    }
}