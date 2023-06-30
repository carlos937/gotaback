using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades.baseEntities
{
    public class BaseEntity
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public bool Lixeira { get; private set; } = false;
        public bool Arquivado { get; private set; } 
        public DateTime? DataDeCadastro { get; protected set; }
        public DateTime? DataDeAtualizacao { get; protected set; }
         
        public void Deletar()
        {
            Lixeira = true;
        }
        public void Arquivar()
        {
            Arquivado = true;
        }
    }
}
