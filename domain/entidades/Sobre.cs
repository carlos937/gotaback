using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Sobre : BaseEntity
    {
 
        public string Descricao { get; private set; }

        private Sobre() { }

        public Sobre(
           string descricao)
        {
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            DataDeAtualizacao = DateTime.Now;
        }
        public void Editar(
           string descricao)
        {
            Descricao = descricao.Trim();
            DataDeAtualizacao = DateTime.Now;
        }
    }
}
