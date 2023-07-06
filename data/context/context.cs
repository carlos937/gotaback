using domain.entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.context
{
    public class Context:DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options):base(options) { 
        
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server =mssql2016.hostingzone.com.br; Database =gotadb; User Id =gota; Password =306090;  TrustServerCertificate=True;");
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Sobre> Sobre { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Inicio> Inicio { get; set; }
    }
}
