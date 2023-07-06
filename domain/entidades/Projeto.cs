using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Projeto : BaseEntity
    { 
        public string Nome { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public Arquivo Imagem { get; private set; }
        public string ImagemId { get; private set; }
        public virtual List<Artista>? Artistas { get; private set; } = new List<Artista>();

        public Projeto()
        {
            
        }

        public Projeto(string nome, string descricao)
        { 
            Nome = nome;
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = DateTime.Now;
        }

        public void Editar(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            DataDeAtualizacao = DateTime.Now;
        }

        public void IncluirArtista(Artista artista)
        {
            Artistas.Add(artista);
            DataDeAtualizacao = DateTime.Now;
        }
        public void LimparArtistas()
        {
            Artistas = new List<Artista>();
            DataDeAtualizacao = DateTime.Now;
        }
    }
}
