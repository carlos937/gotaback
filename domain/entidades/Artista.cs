using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Artista
    {
       public string Id { get; private set; }
       public string Nome { get; private set; }
       public string Celular { get; private set; }
       public string Atuacao { get; private set; }
       private Artista() { }

       public Artista( 
          string nome,  
          string celular,
          string atuacao)
        {
           Id =  Guid.NewGuid().ToString();
           Nome = nome;
           Celular = celular;
           Atuacao = atuacao;
        }
       public void Editar(
          string nome,
          string celular,
          string atuacao)
        {
            Nome = nome;
            Celular = celular;
            Atuacao = atuacao;
        }
    }
}
