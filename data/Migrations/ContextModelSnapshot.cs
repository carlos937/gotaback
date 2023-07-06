﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.context;

#nullable disable

namespace data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("domain.entidades.Artista", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Arquivado")
                        .HasColumnType("bit");

                    b.Property<string>("Atuacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataDeAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdutoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjetoId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("domain.entidades.Contato", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Arquivado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkInstagram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkWhatsapp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkYoutube")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("domain.entidades.Produto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Arquivado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("domain.entidades.Projeto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Arquivado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("domain.entidades.Sobre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Arquivado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataDeAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Lixeira")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sobre");
                });

            modelBuilder.Entity("domain.entidades.Artista", b =>
                {
                    b.HasOne("domain.entidades.Produto", null)
                        .WithMany("Artistas")
                        .HasForeignKey("ProdutoId");

                    b.HasOne("domain.entidades.Projeto", null)
                        .WithMany("Artistas")
                        .HasForeignKey("ProjetoId");
                });

            modelBuilder.Entity("domain.entidades.Produto", b =>
                {
                    b.Navigation("Artistas");
                });

            modelBuilder.Entity("domain.entidades.Projeto", b =>
                {
                    b.Navigation("Artistas");
                });
#pragma warning restore 612, 618
        }
    }
}
