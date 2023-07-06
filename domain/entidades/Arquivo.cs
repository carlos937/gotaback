using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Arquivo : BaseEntity
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }

    }
}
