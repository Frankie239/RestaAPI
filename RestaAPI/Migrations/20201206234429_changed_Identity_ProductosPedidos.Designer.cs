﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaAPI.Models;

namespace RestaAPI.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20201206234429_changed_Identity_ProductosPedidos")]
    partial class changed_Identity_ProductosPedidos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaAPI.Models.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MedioDePagoPreferido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("RestaAPI.Models.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredienteId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("RestaAPI.Models.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDeMesa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MesaId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("RestaAPI.Models.Mozo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mozos");
                });

            modelBuilder.Entity("RestaAPI.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("MozoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MesaId");

                    b.HasIndex("MozoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RestaAPI.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("RestaAPI.Models.ProductoIngrediente", b =>
                {
                    b.Property<int>("ingredienteId")
                        .HasColumnType("int");

                    b.Property<int>("productoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoIngredienteId")
                        .HasColumnType("int");

                    b.HasKey("ingredienteId", "productoId");

                    b.HasIndex("productoId");

                    b.ToTable("ProductoIngredientes");
                });

            modelBuilder.Entity("RestaAPI.Models.ProductoPedido", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoPedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ProductoId", "PedidoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("ProductoPedidos");
                });

            modelBuilder.Entity("RestaAPI.Models.Pedido", b =>
                {
                    b.HasOne("RestaAPI.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("RestaAPI.Models.Mesa", "Mesa")
                        .WithMany("pedidos")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaAPI.Models.Mozo", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("MozoId");
                });

            modelBuilder.Entity("RestaAPI.Models.ProductoIngrediente", b =>
                {
                    b.HasOne("RestaAPI.Models.Ingrediente", "Ingrediente")
                        .WithMany("ProductoIngredientes")
                        .HasForeignKey("ingredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaAPI.Models.Producto", "Producto")
                        .WithMany("ProductoIngredientes")
                        .HasForeignKey("productoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaAPI.Models.ProductoPedido", b =>
                {
                    b.HasOne("RestaAPI.Models.Pedido", "Pedido")
                        .WithMany("ProductoPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaAPI.Models.Producto", "Producto")
                        .WithMany("ProductoPedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
