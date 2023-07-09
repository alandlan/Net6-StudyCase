
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Net6StudyCase.Store.Infra.Database.Context;

    public class ProdutoDbContext : DbContext
    {
        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> opts) : base (opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }
    }
