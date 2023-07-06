using domain.entidades.baseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entidades
{
    public class Contato:BaseEntity
    {
        public string Endereco { get; private set; }
        public string LinkInstagram { get; private set; }
        public string LinkWhatsapp { get; private set; }
        public string LinkYoutube { get; private set; }
        private Contato() { }

        public Contato(string endereco, string linkInstagram, string linkWhatsapp, string linkYoutube)
        {
            Endereco = endereco;
            LinkInstagram = linkInstagram;
            LinkWhatsapp = linkWhatsapp;
            LinkYoutube = linkYoutube;
            DataDeAtualizacao =  DateTime.Now;
            DataDeCadastro =  DateTime.Now;
        }
        public void Editar(string endereco, string linkInstagram, string linkWhatsapp, string linkYoutube)
        {
            Endereco = endereco;
            LinkInstagram = linkInstagram;
            LinkWhatsapp = linkWhatsapp;
            LinkYoutube = linkYoutube;
            DataDeAtualizacao = DateTime.Now; 
        }
    }
}
