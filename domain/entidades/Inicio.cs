using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Inicio :BaseEntity
    {
        public List<Arquivo> Imagens { get; set; }
        private Inicio() { } 

        public void AdicionarImagem(Arquivo imagem)
        {
            Imagens.Add(imagem);
        }

    }
}
