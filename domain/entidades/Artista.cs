using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Artista : BaseEntity
    {

        public Arquivo Imagem { get; private set; }
        public string ImagemId { get; private set; }
        public string Nome { get; private set; }
        public string Celular { get; private set; }
        public string Atuacao { get; private set; }

        private Artista() { }

        public Artista(
           string nome,
           string celular,
           string atuacao)
        {
            Nome = nome;
            Celular = celular;
            Atuacao = atuacao;
            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = DateTime.Now;
        }
        public void Editar(
           string nome,
           string celular,
           string atuacao)
        {
            Nome = nome;
            Celular = celular;
            Atuacao = atuacao;
            DataDeAtualizacao = DateTime.Now;
        }
    }
}
