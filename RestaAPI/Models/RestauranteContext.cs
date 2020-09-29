using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaAPI.Models
{


    
    public partial class RestauranteContext : DbContext
    {
        public DbSet<Mozo> Mozos{get;set;}
        
        public DbSet<Cliente> clientes {set;get;}
        public DbSet<Mesa> Mesas {set;get;}
        public DbSet<Producto> Productos{set;get;}
        public DbSet<Ingrediente> Ingredientes {set;get;}
        public DbSet<Pedido> Pedidos {set;get;}
        public DbSet<ProductoIngrediente> ProductoIngredientes {set;get;}
        public DbSet<ProductoPedido> ProductoPedidos {set;get;}
        public RestauranteContext()
        {

           
        }

        public RestauranteContext(DbContextOptions<RestauranteContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                //optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Restaurante; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnModelCreatingPartial(modelBuilder);


            modelBuilder.Entity<ProductoIngrediente>().HasKey(pi => new{pi.ingredienteId, pi.productoId});

            modelBuilder.Entity<ProductoIngrediente>()
            .HasOne<Producto>(pi => pi.Producto)
            .WithMany(p => p.ProductoIngredientes)
            .HasForeignKey(pi => pi.productoId);


            modelBuilder.Entity<ProductoIngrediente>()
            .HasOne<Ingrediente>(pi => pi.Ingrediente)
            .WithMany(i => i.ProductoIngredientes)
            .HasForeignKey(pi => pi.ingredienteId);

            modelBuilder.Entity<ProductoPedido>().HasKey(pp => new {pp.ProductoId, pp.PedidoId});


            modelBuilder.Entity<ProductoPedido>()
            .HasOne<Producto>(pp => pp.Producto)
            .WithMany(p => p.ProductoPedidos)
            .HasForeignKey(pp => pp.ProductoId);


            modelBuilder.Entity<ProductoPedido>()
            .HasOne<Pedido>(pp => pp.Pedido)
            .WithMany(p => p.ProductoPedidos)
            .HasForeignKey(pp => pp.PedidoId);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
