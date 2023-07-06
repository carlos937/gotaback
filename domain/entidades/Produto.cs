using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Produto:BaseEntity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public double Valor { get; private set; } 
        public Arquivo Imagem { get; private set; }
        public string ImagemId { get; private set; }
        public List<Artista> Artistas { get; private set; } = new List<Artista>();
        private Produto() { }

        public Produto(string titulo, string descricao, double valor, List<Artista> artistas)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            Artistas = artistas;
            DataDeAtualizacao = DateTime.Now;
            DataDeCadastro = DateTime.Now;
        }

        public void Editar(string titulo, string descricao, double valor, List<Artista> artistas)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            Artistas = artistas;
            DataDeAtualizacao = DateTime.Now; 
        }
    }
}
